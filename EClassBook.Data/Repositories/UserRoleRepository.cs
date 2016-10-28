namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;

    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(EBookContext context)
            : base(context)
        { }
    }
}
