namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model.Entities;
    using Model.Repositories;

    public class CourseRepository : EntityBaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(EBookContext context)
            : base(context)
        { }
    }
}
