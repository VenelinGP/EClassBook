namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;

    public class GroupRepository : EntityBaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(EBookContext context)
            : base(context)
        { }
    }
}
