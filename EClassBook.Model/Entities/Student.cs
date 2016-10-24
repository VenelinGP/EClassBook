namespace EClassBook.Model.Entities
{
    using System;
    using System.Collections.Generic;

    public class Student
    { 
        private ICollection<Grade> grades;

        public Student()
        {
            this.grades = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Grade> Grades
        {
            get { return this.grades; }
            set { this.grades = value; }
        }
    }
}
