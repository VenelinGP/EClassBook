namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;

    public class ClassRepository : EntityBaseRepository<ClassGroup>, IClassRepository
    {
        public ClassRepository(EBookContext context)
            : base(context)
        { }
    }
}
