namespace EClassBook.Model
{
    using Common.Models;
    using System.Collections.Generic;

    public class Group : BaseModel
    {
        private ICollection<User> users;

        public Group()
        {
            this.users = new HashSet<User>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Users{ get; set; }
    }
}