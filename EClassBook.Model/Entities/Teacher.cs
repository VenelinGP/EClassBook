namespace EClassBook.Model.Entities
{
    using System.Collections.Generic;
    using Common.Models;


    public class Teacher : BaseModel<int>
    {
        private ICollection<Course> courses;

        public Teacher()
        {
            this.courses = new HashSet<Course>();
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
