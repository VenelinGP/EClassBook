namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;
    using System.Collections.Generic;

    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository
    {
        IRoleRepository roleReposistory;
        public StudentRepository(EBookContext context, IRoleRepository roleReposistory)
            : base(context)
        {
            this.roleReposistory = roleReposistory;
        }

        public Student GetSingleByUsername(string username)
        {
            return this.GetSingle(x => x.Username == username);
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            List<Role> roles = null;

            Student user = this.GetSingle(u => u.Username == username, u => u.UserRoles);
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
