namespace EClassBook.Data.Service
{
    using Common.Models;
    using Contracts;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;

    public class MembershipService : IMembershipService
    {

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IEncryptionService encryptionService;

        public MembershipService(IUserRepository userRepository,
                                IRoleRepository roleRepository,
                                IEncryptionService encryptionService)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.encryptionService = encryptionService;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRole = GetUserRoles(user.Username);
                membershipCtx.User = user;
                string[] userRoles = new string[] { userRole.Name };
                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles);
            }

            return membershipCtx;
        }
        public User CreateUser(string username, string firstName, string lastName, string email, string password, int role)
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
                HashedPassword = encryptionService.EncryptPassword(password, passwordSalt),
                RoleId = role
            };

            userRepository.Add(user);

            userRepository.Commit();

            //if (roles != null || roles.Length > 0)
            //{
            //    foreach (var role in roles)
            //    {
            //        addUserToRole(user, role);
            //    }
            //}

            //userRepository.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return userRepository.GetSingle(userId);
        }

        public Role GetUserRoles(string username)
        {
            int roleId = 0;
            Role result = null;

            var existingUser = userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                roleId = existingUser.RoleId;
                result = roleRepository.GetSingle(roleId);
            }

            return result;
        }

        private void addUserToRole(User user, int roleId)
        {
            //var role = roleRepository.GetSingle(roleId);
            //if (role == null)
            //    throw new Exception("Role doesn't exist.");

            //var userRole = new UserRole()
            //{
            //    RoleId = role.Id,
            //    UserId = user.Id
            //};
            //userRoleRepository.Add(userRole);

            //userRepository.Commit();
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
