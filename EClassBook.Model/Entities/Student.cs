namespace EClassBook.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using Common.Models;


    public class Student : BaseModel<int>
    {
        private ICollection<Grade> grades;

        public Student()
        {
            this.grades = new HashSet<Grade>();
        }

        public string Name { get; set; }

        public string Password { get; set; }

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
