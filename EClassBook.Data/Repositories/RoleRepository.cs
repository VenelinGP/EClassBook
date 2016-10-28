namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;

    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(EBookContext context)
            : base(context)
        { }
    }
}
