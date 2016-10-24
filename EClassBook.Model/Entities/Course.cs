namespace EClassBook.Model.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
