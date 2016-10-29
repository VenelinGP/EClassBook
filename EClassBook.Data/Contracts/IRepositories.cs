namespace EClassBook.Common.Models
{
    using Model;
    using System.Collections.Generic;

    public interface IAddressRepository : IEntityBaseRepository<Address> { }

    public interface IClassRepository : IEntityBaseRepository<Class> { }

    public interface ICourseRepository : IEntityBaseRepository<Course> { }

    public interface ILoggingRepository : IEntityBaseRepository<Error> { }

    public interface IGradeRepository : IEntityBaseRepository<Grade> { }

    public interface IUserRepository : IEntityBaseRepository<User>
    {
        User GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }

    public interface IRoleRepository : IEntityBaseRepository<Role> { }

    public interface IUserRoleRepository : IEntityBaseRepository<UserRole> { }
}
