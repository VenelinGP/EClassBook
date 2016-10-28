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
 
        private readonly IHeadmasterRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IEncryptionService _encryptionService;

        public MembershipService(IHeadmasterRepository headmasterRepository, IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository, IEncryptionService encryptionService)
        {
            _userRepository = headmasterRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
        }

        #region IMembershipService Implementation

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
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
        public Headmaster CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();
            var address = new Address
            {
                Email = email
            };
            var headmaster = new Headmaster()
            {
                Username = username,
                Salt = passwordSalt,
                Address = address,
                IsLocked = false,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt)
            };

            _userRepository.Add(headmaster);

            _userRepository.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(headmaster, role);
                }
            }

            _userRepository.Commit();

            return headmaster;
        }

        public Headmaster GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    _result.Add(userRole.Role);
                }
            }

            return _result.Distinct().ToList();
        }
        #endregion

        #region Helper methods
        private void addUserToRole(Headmaster user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId);
            if (role == null)
                throw new Exception("Role doesn't exist.");

            var userRole = new UserRole()
            {
                RoleId = role.Id,
                UserId = user.Id
            };
            _userRoleRepository.Add(userRole);

            _userRepository.Commit();
        }

        private bool isPasswordValid(Headmaster user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
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
