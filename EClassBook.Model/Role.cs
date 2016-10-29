namespace EClassBook.Model
{
    using Common.Models;
    using System.Collections.Generic;

    public class Role : BaseModel
    {
        private ICollection<User> users;

        public RoleEnum Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
