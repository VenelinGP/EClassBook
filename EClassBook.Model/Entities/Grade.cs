namespace EClassBook.Model.Entities
{
    using System;
    using Common.Models;

    public class Grade :BaseModel<int>
    {
        public DateTime Date { get; set; }

        public GradeEnum GradeValue { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
