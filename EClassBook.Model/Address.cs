namespace EClassBook.Model.Entities
{
    using Common.Models;

    public class Address : BaseModel
    {
        public string Email { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PhoneNumber { get; set; }
    }
}
