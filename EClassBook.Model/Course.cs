namespace EClassBook.Model
{
    using Common.Models;

    public class Course : BaseModel
    {
        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
