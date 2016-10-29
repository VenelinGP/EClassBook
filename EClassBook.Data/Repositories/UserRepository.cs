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

        public Role GetUserRoles(string username)
        {
            //List<Role> roles = null;

            //User user = this.GetSingle(u => u.Username == username, u => u.UserRoles);
            //if (user != null)
            //{
            //    roles = new List<Role>();
            //    foreach (var userRole in user.UserRoles)
            //    {
            //        roles.Add(roleReposistory.GetSingle(userRole.RoleId));
            //    }

            //}
            Role roles = null;
            User user = this.GetSingle(u => u.Username == username, u => u.Role);
            if (user != null)
            {
                roles = roleReposistory.GetSingle(user.RoleId);
            }
                return roles;
        }
    }
}