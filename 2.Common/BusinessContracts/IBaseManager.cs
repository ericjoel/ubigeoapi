using System.Collections.Generic;

namespace Common.BusinessContracts
{
    public interface IBaseManager<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> PageAll(int skip, int take);

        TEntity FindById(object id);

        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
