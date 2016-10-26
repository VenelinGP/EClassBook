namespace EClassBook.Model.Entities
{
    using Common.Models;

    public class Role : BaseModel<int>
    {
        public RoleEnum Name { get; set; }
    }
}
