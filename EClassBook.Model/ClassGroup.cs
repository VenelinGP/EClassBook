namespace EClassBook.Model
{
    using Common.Models;
    using System.Collections.Generic;

    public class ClassGroup : BaseModel
    {
        private ICollection<User> users;

        public ClassGroup()
        {
            this.users = new HashSet<User>();
        }

        public string Name { get; set; }


        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

    }
}