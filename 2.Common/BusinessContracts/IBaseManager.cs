using System.Collections.Generic;

namespace Common.BusinessContracts
{
    /// <summary>
    /// Base Manager interface
    /// </summary>
    /// <typeparam name="TEntity">Model Generic passed by class</typeparam>
    public interface IBaseManager<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Get all data of an specified model
        /// </summary>
        /// <returns>All models</returns>
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> PageAll(int skip, int take);
        
        /// <summary>
        /// Get a model by specified id
        /// </summary>
        /// <param name="id">if to search</param>
        /// <returns>Model searched or null</returns>
        TEntity FindById(object id);

        /// <summary>
        /// Add an specified model 
        /// </summary>
        /// <param name="entity">model to insert</param>
        /// <returns>model with id</returns>
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
