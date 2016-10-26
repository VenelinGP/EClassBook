namespace EClassBook.Model.Entities
{
    using System.Collections.Generic;

    public class Teacher
    {
        private ICollection<Course> courses;

        public Teacher()
        {
            this.courses = new HashSet<Course>();
        }

        public int TeacherId { get; set; }

        public string Name { get; set; }

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
