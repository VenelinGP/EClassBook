namespace EClassBook.Model
{
    using Common.Models;

    public class Course : BaseModel
    {
        public string Name { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
