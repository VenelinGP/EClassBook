namespace EClassBook.Model.Entities
{
    public class Headmaster
    {
        public int HeadmasterId { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
