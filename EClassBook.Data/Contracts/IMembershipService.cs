namespace EClassBook.Data.Contracts
{
    using Data;
    using Model;
    using System.Collections.Generic;

    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string firstName, string lastName, string email, string password, int role);
        User GetUser(int userId);
        Role GetUserRoles(string username);
    }
}