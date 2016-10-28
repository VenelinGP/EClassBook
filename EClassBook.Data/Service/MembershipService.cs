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
 
        private readonly IHeadmasterRepository headmasterRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IEncryptionService encryptionService;

        public MembershipService(IHeadmasterRepository headmasterRepository, IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository, IEncryptionService encryptionService)
        {
            this.headmasterRepository = headmasterRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.encryptionService = encryptionService;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = headmasterRepository.GetSingleByUsername(username);
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
        public Headmaster CreateUser(string username, string firstName, string lastName, string email, string password, int[] roles)
        {
            var existingUser = headmasterRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = encryptionService.CreateSalt();
            var address = new Address
            {
                Email = email
            };
            var headmaster = new Headmaster()
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Salt = passwordSalt,
                Address = address,
                IsLocked = false,
                HashedPassword = encryptionService.EncryptPassword(password, passwordSalt)
            };

            headmasterRepository.Add(headmaster);

            headmasterRepository.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(headmaster, role);
                }
            }

            headmasterRepository.Commit();

            return headmaster;
        }

        public Headmaster GetUser(int userId)
        {
            return headmasterRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = headmasterRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    _result.Add(userRole.Role);
                }
            }

            return _result.Distinct().ToList();
        }

        #region Helper methods
        private void addUserToRole(Headmaster user, int roleId)
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

            headmasterRepository.Commit();
        }

        private bool isPasswordValid(Headmaster user, string password)
        {
            return string.Equals(encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool isUserValid(Headmaster user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }
        #endregion
    }
}
