using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Common.DataAccessContracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> PageAll(int skip, int take);
        TEntity FindById(object id);

        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
