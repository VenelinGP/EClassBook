namespace EClassBook.Data
{
    using Model;
    using System.Security.Principal;

    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public Headmaster User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
