using System.Threading.Tasks;

namespace Invest.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool>  Delete(TEntity entity);        
    }
}
