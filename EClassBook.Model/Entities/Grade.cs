namespace EClassBook.Model.Entities
{
    using System;

    public class Grade
    {
        public int GradeId { get; set; }
        public DateTime Date { get; set; }

        public GradeEnum GradeValue { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}
