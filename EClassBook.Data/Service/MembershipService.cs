namespace EClassBook.Data.Service
{
    using Common.Models;
    using Contracts;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;

    public class MembershipService : IMembershipService
    {

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IEncryptionService encryptionService;

        public MembershipService(IUserRepository userRepository,
                                IRoleRepository roleRepository,
                                IUserRoleRepository userRoleRepository,
                                IEncryptionService encryptionService)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.encryptionService = encryptionService;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Username);
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name.ToString()).ToArray());
            }

            return membershipCtx;
        }
        public User CreateUser(string username, string firstName, string lastName, string email, string password, int[] roles)
        {
            var existingUser = userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = encryptionService.CreateSalt();
            var address = new Address
            {
                Email = email
            };
            var user = new User()
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Salt = passwordSalt,
                Address = address,
                IsLocked = false,
                HashedPassword = encryptionService.EncryptPassword(password, passwordSalt)
            };

            userRepository.Add(user);

            userRepository.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(user, role);
                }
            }

            userRepository.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> result = new List<Role>();

            var existingUser = userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    result.Add(userRole.Role);
                }
            }

            return result.Distinct().ToList();
        }

        private void addUserToRole(User user, int roleId)
        {
            var role = roleRepository.GetSingle(roleId);
            if (role == null)
                throw new Exception("Role doesn't exist.");

            var userRole = new UserRole()
            {
                RoleId = role.Id,
                UserId = user.Id
            };
            userRoleRepository.Add(userRole);

            userRepository.Commit();
        }

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }
    }
}
