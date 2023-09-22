

using BookManagement.Models;
using BookManagement.Repositories.Interfaces;

namespace BookManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext db;
        public UnitOfWork(BookDbContext db)
        {
            this.db = db;
        }
        public IGenericRepo<T> GetRepo<T>() where T : class, new()
        {
            return new GenericRepo<T>(db);
        }
        public async Task<bool> SaveAsync()
        {
            int rowsEffected = await db.SaveChangesAsync();
            return rowsEffected > 0;
        }
    }
}
