namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model;
    using Model.Repositories;

    public class GradeRepository : EntityBaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(EBookContext context)
            : base(context)
        { }
    }
}