namespace EClassBook.Model
{
    using Common.Models;
    using System.Collections.Generic;

    public class User : BaseModel
    {
        private ICollection<Course> courses;
        private ICollection<Grade> grades;
        private ICollection<UserRole> userRoles;

        public User()
        {
            this.courses = new HashSet<Course>();
            this.grades = new HashSet<Grade>();
        }


        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Course> Course
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
        public virtual ICollection<Grade> Grades
        {
            get { return this.grades; }
            set { this.grades = value; }
        }
        public virtual ICollection<UserRole> UserRoles
        {
            get { return this.userRoles; }
            set { this.userRoles = value; }
        }

    }
}
