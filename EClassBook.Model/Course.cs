namespace EClassBook.Model
{
    using Common.Models;
    using System.Collections.Generic;

    public class Course : BaseModel
    {
        private ICollection<Grade> grades;

        public Course()
        {
            this.grades = new HashSet<Grade>();
        }

        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
