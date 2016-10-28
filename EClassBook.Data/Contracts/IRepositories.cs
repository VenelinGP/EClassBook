namespace EClassBook.Common.Models
{
    using Model;
    using System.Collections.Generic;

    public interface IAddressRepository : IEntityBaseRepository<Address> { }

    public interface ICourseRepository : IEntityBaseRepository<Course> { }

    public interface ILoggingRepository : IEntityBaseRepository<Error> { }

    public interface IGradeRepository : IEntityBaseRepository<Grade> { }

    public interface IHeadmasterRepository : IEntityBaseRepository<Headmaster>
    {
        Headmaster GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }

    public interface ITeacherRepository : IEntityBaseRepository<Teacher>
    {
        Teacher GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }

    public interface IStudentRepository : IEntityBaseRepository<Student>
    {
        Student GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }

    public interface IRoleRepository : IEntityBaseRepository<Role> { }

    public interface IUserRoleRepository : IEntityBaseRepository<UserRole> { }
}
