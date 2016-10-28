namespace EClassBook.Data
{
    using System;
    using System.Linq;
    using Model.Entities;
    using System.Collections.Generic;

    public class PersonDbInitializer
    {
        private static EBookContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (EBookContext)serviceProvider.GetService(typeof(EBookContext));
            InitializePersons();
        }

        private static void InitializePersons()
        {
            //if (!context.Persons.Any())
            //{
            //    Person person_01 = new Person { Name = "Max Musterman", City = "Nausadt", Dob = new DateTime(1978, 7, 29) };
            //    Person person_02 = new Person { Name = "Maria Musterfrau", City = "London", Dob = new DateTime(1979, 8, 30) };
            //    Person person_03 = new Person { Name = "John Doe", City = "Los Angeles", Dob = new DateTime(1980, 09, 1) };
            //    Person person_04 = new Person { Name = "Chris Sakellarios", City = "Paris", Dob = new DateTime(1981, 10, 5) };
            //    Person person_05 = new Person { Name = "Charlene Campbell", City = "Bruxelles", Dob = new DateTime(1982, 11, 12) };
            //    Person person_06 = new Person { Name = "Mattie Lyons", City = "Lyon", Dob = new DateTime(1983, 12, 6) };
            //    context.Persons.Add(person_01);
            //    context.Persons.Add(person_02);
            //    context.Persons.Add(person_03);
            //    context.Persons.Add(person_04);
            //    context.Persons.Add(person_05);
            //    context.Persons.Add(person_06);
            //    context.SaveChanges();
            //}

            if (!context.Headmasters.Any())
            {
                Console.WriteLine("Here");
                var role = new List<UserRole>();
                    role.Add( new UserRole() { UserId = 1 } );
                Address address = new Address { City = "Sofia", Street = "31, Al. Malinov blvd", PhoneNumber = "0888308000" };
                Headmaster headmaster_01 = new Headmaster { FirstName = "Max", LastName ="Musterman", Address = address, UserRoles = role };
                context.Headmasters.Add(headmaster_01);
                context.SaveChanges();
            }
        }
    }
}
