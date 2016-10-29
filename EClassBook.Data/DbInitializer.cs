namespace EClassBook.Data
{
    using System;
    using System.Linq;
    using Model;

    public class DbInitializer
    {
        private static EBookContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (EBookContext)serviceProvider.GetService(typeof(EBookContext));
            InitializeUserRoles();
        }
        private static void InitializeUserRoles()
        {
            if (!context.Roles.Any())
            {
                // create roles
                context.Roles.AddRange(new Role[]
                {
                    new Role() { Name="Admin" },
                    new Role() { Name="Teacher" },
                    new Role() { Name="Student" }
                });

                context.SaveChanges();
            }
            if (!context.Address.Any())
            {
                context.Address.Add(
                    new Address()
                    {
                        Email = "venelin.petkov@netcoms.eu",
                        City = "Sliven",
                        Street = "2, Petko Karavelov str.",
                        PhoneNumber = "0889919030"
                    });
                context.SaveChanges();
            }
            if (!context.User.Any())
            {
                context.User.Add(new User()
                {
                    Username = "master",
                    FirstName = "Venelin",
                    LastName = "Petkov",
                    HashedPassword = "9wsmLgYM5Gu4zA/BSpxK2GIBEWzqMPKs8wl2WDBzH/4=",
                    Salt = "GTtKxJA6xJuj3ifJtTXn9Q==",
                    IsLocked = false,
                    AddressId = 1,
                    RoleId = 1
                });
                // create user-addres for venelin

                // create user - admin for venelin

                //context.UserRoles.AddRange(new UserRole[] {
                //    new UserRole() {
                //        RoleId = 1, // admin
                //        UserId = 1  // Venelin
                //    }
                // });
                //context.SaveChanges();
            }
            if (!context.Courses.Any())
            {
                context.AddRange(new Course[]
                {
                    new Course() { Name="Български език" },
                    new Course() { Name="Математика" },
                    new Course() { Name="Физика" },
                    new Course() { Name="Английски език" },
                    new Course() { Name="География" },
                    new Course() { Name="История" },
                    new Course() { Name="Химия" },
                    new Course() { Name="Биология" },
                    new Course() { Name="Информационни технологии" },
                    new Course() { Name="Изобразително изкуство" },
                    new Course() { Name="Музика" },
                    new Course() { Name="Физическо и спорт" },
                });

                context.SaveChanges();
            }
        }
    }

    //private static void InitializePersons()
    //{
    //    if (!context.Headmasters.Any())
    //    {
    //        Console.WriteLine("Here");
    //        var role = new List<UserRole>();
    //            role.Add( new UserRole() { UserId = 1 } );
    //        Address address = new Address { City = "Sofia", Street = "31, Al. Malinov blvd", PhoneNumber = "0888308000" };
    //        Headmaster headmaster_01 = new Headmaster { FirstName = "Max", LastName ="Musterman", Address = address, UserRoles = role };
    //        context.Headmasters.Add(headmaster_01);
    //        context.SaveChanges();
    //    }
    //}
}

