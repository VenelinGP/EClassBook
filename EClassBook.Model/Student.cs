namespace EClassBook.Model
{
    using System;
    using System.Collections.Generic;
    using Common.Models;


    public class Student : BaseModel
    {
        private ICollection<Grade> grades;
        private ICollection<UserRole> userRoles;


        public Student()
        {
            this.grades = new HashSet<Grade>();
            userRoles = new HashSet<UserRole>();

        }

        public string Name { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLoked { get; set; }

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
        public virtual ICollection<UserRole> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }

    }
}
