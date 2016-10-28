namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model.Entities;
    using Model.Repositories;

    public class GradeRepository : EntityBaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(EBookContext context)
            : base(context)
        { }
    }
}