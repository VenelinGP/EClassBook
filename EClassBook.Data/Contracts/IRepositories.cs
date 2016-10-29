namespace EClassBook.Common.Models
{
    using Model;
    using System.Collections.Generic;

    public interface IAddressRepository : IEntityBaseRepository<Address> { }

    public interface IClassRepository : IEntityBaseRepository<ClassGroup> { }

    public interface ICourseRepository : IEntityBaseRepository<Course> { }

    public interface ILoggingRepository : IEntityBaseRepository<Error> { }

    public interface IGradeRepository : IEntityBaseRepository<Grade> { }

    public interface IUserRepository : IEntityBaseRepository<User>
    {
        User GetSingleByUsername(string username);
        Role GetUserRoles(string username);
    }

    public interface IRoleRepository : IEntityBaseRepository<Role> { }
}
