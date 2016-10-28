namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model.Entities;
    using Model.Repositories;

    public class AddressRepository : EntityBaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(EBookContext context)
            : base(context)
        { }
    }
}
