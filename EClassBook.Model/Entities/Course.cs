namespace EClassBook.Model.Entities
{
    using Common.Models;

    public class Course : BaseModel<int>
    {
        public string Name { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
