namespace EClassBook.Model.Entities
{
    using System;
    using Model;

    public class Person : IPerson
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public DateTime Dob { get; set; }
    }
}
