namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;
    using System.Collections.Generic;

    public class TeacherRepository : EntityBaseRepository<Teacher>, ITeacherRepository
    {
        IRoleRepository roleReposistory;
        public TeacherRepository(EBookContext context, IRoleRepository roleReposistory)
            : base(context)
        {
            this.roleReposistory = roleReposistory;
        }

        public Teacher GetSingleByUsername(string username)
        {
            return this.GetSingle(x => x.Username == username);
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            List<Role> roles = null;

            Teacher user = this.GetSingle(u => u.Username == username, u => u.UserRoles);
            if (user != null)
            {
                roles = new List<Role>();
                foreach (var userRole in user.UserRoles)
                    roles.Add(this.roleReposistory.GetSingle(userRole.RoleId));
            }

            return roles;
        }
    }
}
