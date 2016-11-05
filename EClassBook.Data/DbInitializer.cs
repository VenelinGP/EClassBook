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
                context.Address.Add(
                    new Address()
                    {
                        Email = "ivan.ivanov@gmail.eu",
                        City = "Sofia",
                        Street = "1, str",
                        PhoneNumber = "0888888881"
                    });
                context.Address.Add(
                    new Address()
                    {
                        Email = "petar.petrov@gmail.eu",
                        City = "Sofia",
                        Street = "2, str",
                        PhoneNumber = "0888888882"
                    });
                context.Address.Add(
                    new Address()
                    {
                        Email = "stanimir.andreev@gmail.eu",
                        City = "Sofia",
                        Street = "3, str",
                        PhoneNumber = "0888888881"
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
                context.User.Add(new User()
                {
                    Username = "iv1784",
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    HashedPassword = "mNKopj2efeRvymuXuh7mPlPUTCgcSWxgjjwTu81A6PU=",
                    Salt = "rFPWsKNemjbh/6pU0SgOWQ==",
                    IsLocked = false,
                    AddressId = 2,
                    RoleId = 2
                });
                context.User.Add(new User()
                {
                    Username = "pv1894",
                    FirstName = "Petar",
                    LastName = "Petrov",
                    HashedPassword = "fVzqOHiFdEnbLok8yJfA6ClJ50mAyxYe4HRti+TMtpQ=",
                    Salt = "11D8qk5uxxEP/gBTbm/Ysw==",
                    IsLocked = false,
                    AddressId = 3,
                    RoleId = 2
                });
                context.User.Add(new User()
                {
                    Username = "sv1243",
                    FirstName = "Stanimir",
                    LastName = "Andreev",
                    HashedPassword = "eexTx6FQmehrbU9VZfoF68G6wl6tAjmS9ELOswp3gN0=",
                    Salt = "1N7Ef79voetSkdyDdidpeA==",
                    IsLocked = false,
                    AddressId = 4,
                    RoleId = 2
                });
                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                context.Courses.Add( new Course() { Name = "Български език", UserId = 1 });
                context.Courses.Add( new Course() { Name = "Математика", UserId = 2 });
                context.Courses.Add( new Course() { Name = "Физика", UserId = 2 });
                context.Courses.Add( new Course() { Name = "Английски език", UserId = 1 });
                context.Courses.Add( new Course() { Name = "География", UserId = 3 });
                context.Courses.Add(new Course() { Name = "История", UserId = 4 });
                context.Courses.Add(new Course() { Name = "Химия", UserId = 3 });
                context.Courses.Add(new Course() { Name = "Биология", UserId = 4 });
                context.Courses.Add(new Course() { Name = "Информационни технологии", UserId = 2 });
                //context.Courses.Add( new Course() { Name = "Изобразително изкуство" });
                //context.Courses.Add( new Course() { Name = "Музика" });
                //context.Courses.Add( new Course() { Name = "Физическо и спорт" });

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

