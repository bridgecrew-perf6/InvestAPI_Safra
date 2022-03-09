using Invest.Repositories.Context;
using Invest.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace Invest.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public virtual Task<object> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
