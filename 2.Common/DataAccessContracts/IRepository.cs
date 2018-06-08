using System.Collections.Generic;

namespace Common.DataAccessContracts
{
    /// <summary>
    /// Class with all commons methods in repository
    /// </summary>
    /// <typeparam name="TEntity">Generic class</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all the collection of model
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> PageAll(int skip, int take);
        /// <summary>
        /// Find an specified register in collection by id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns></returns>
        TEntity FindById(object id);

        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
