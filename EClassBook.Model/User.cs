namespace EClassBook.Model
{
    using Common.Models;
    using System.Collections.Generic;

    public class User : BaseModel
    {
        private ICollection<Course> courses;

        public User()
        {
            this.courses = new HashSet<Course>();
        }


        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
