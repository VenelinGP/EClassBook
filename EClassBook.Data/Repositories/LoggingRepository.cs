namespace EClassBook.Data.Repositories
{
    using Common.Models;
    using Model.Entities;
    using Model.Repositories;

    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    {
        public LoggingRepository(EBookContext context)
            : base(context)
        { }

        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
