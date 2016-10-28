namespace EClassBook.Model.Entities
{
    using Common.Models;

    public class UserRole : BaseModel
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}
