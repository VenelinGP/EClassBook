namespace EClassBook.Data.Contracts
{
    using Data;
    using Model;
    using System.Collections.Generic;

    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        Headmaster CreateUser(string username, string email, string password, int[] roles);
        Headmaster GetUser(int userId);
        List<Role> GetUserRoles(string username);
    }
}