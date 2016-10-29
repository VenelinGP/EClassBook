namespace EClassBook.Model
{
    using Common.Models;

    public class Course : BaseModel
    {
        public string Name { get; set; }

        public string TeacherName { get; set; }
    }
}
