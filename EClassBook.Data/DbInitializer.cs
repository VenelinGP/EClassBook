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
                new Role()
                {
                    Name=RoleEnum.Admin
                },
                new Role()
                {
                    Name=RoleEnum.Teacher
                },
                new Role()
                {
                    Name=RoleEnum.Student
                }
                });

                context.SaveChanges();
            }
            if (!context.Address.Any())
            {
                context.Address.Add(
                    new Address()
                    {
                        Email = "venelin.petkov@netcoms.eu"
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
                    AddressId = 1
                });
                // create user-addres for venelin

                // create user-admin for venelin
                //context.UserRoles.AddRange(new UserRole[] {
                //new UserRole() {
                //    RoleId = 1, // admin
                //    UserId = 1  // Venelin
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

