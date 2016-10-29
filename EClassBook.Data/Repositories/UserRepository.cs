namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;
    using System.Collections.Generic;

    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        IRoleRepository roleReposistory;
        public UserRepository(EBookContext context, IRoleRepository roleReposistory)
            : base(context)
        {
            this.roleReposistory = roleReposistory;
        }

        public User GetSingleByUsername(string username)
        {
            return this.GetSingle(x => x.Username == username);
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            List<Role> roles = null;

            User _user = this.GetSingle(u => u.Username == username, u => u.UserRoles);
            if (_user != null)
            {
                roles = new List<Role>();
                foreach (var userRole in _user.UserRoles)
                {
                    roles.Add(roleReposistory.GetSingle(userRole.RoleId));
                }
                    
            }

            return roles;
        }
    }
}