namespace EClassBook.Model.Entities
{
    using Common.Models;

    public class Headmaster : BaseModel<int>
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
