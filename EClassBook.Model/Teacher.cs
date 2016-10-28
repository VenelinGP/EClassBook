namespace EClassBook.Model
{
    using System.Collections.Generic;
    using Common.Models;


    public class Teacher : BaseModel
    {
        private ICollection<Course> courses;
        private ICollection<UserRole> userRoles;

        public Teacher()
        {
            this.courses = new HashSet<Course>();
            userRoles = new HashSet<UserRole>();
        }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLoked { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<UserRole> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }
    }
}
