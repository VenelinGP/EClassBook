namespace EClassBook.Common.Models
{
    using Model;

    public interface IAddressRepository : IEntityBaseRepository<Address> { }

    public interface IGroupRepository  : IEntityBaseRepository<Group> { }

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
