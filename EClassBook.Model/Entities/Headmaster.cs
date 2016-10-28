namespace EClassBook.Model.Entities
{
    using Common.Models;
    using System.Collections.Generic;

    public class Headmaster : BaseModel
    {
        private ICollection<UserRole> userRoles;

        public Headmaster()
        {
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

        public virtual ICollection<UserRole> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }
    }
}
