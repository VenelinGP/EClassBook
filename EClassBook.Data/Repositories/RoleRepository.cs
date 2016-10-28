namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model.Entities;
    using Model.Repositories;

    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(EBookContext context)
            : base(context)
        { }
    }
}
