using System.Collections.Generic;
using Common.DataAccessContracts;
using MongoDB.Driver;
using System.Linq;

namespace DataAccess
{
    /// <summary>
    /// Implement of generic repository, to avoid implement in multiple classes
    /// </summary>
    /// <typeparam name="TEntity">Generic model</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMongoClient _client;
        private IMongoDatabase _mongoDataBase;
        protected IMongoCollection<TEntity> Collection;

        /// <summary>
        /// Construct generic repository
        /// </summary>
        /// <param name="mongoClient">Inject mongoclient</param>
        public Repository(IMongoClient mongoClient)
        {
            _client = mongoClient;
            //Specified the database to use in project
            _mongoDataBase = mongoClient.GetDatabase("PoliceStore");
            //Assign the collection by class name
            Collection = _mongoDataBase.GetCollection<TEntity>(typeof(TEntity).Name);            
        }
        /// <summary>
        /// Generic method to get all registers in collection
        /// </summary>
        /// <returns>list of models</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Collection.Find(_ => true).ToEnumerable();
        }

        /// <summary>
        /// Page all the model 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> PageAll(int skip, int take)
        {
            return Collection.AsQueryable().Where(_ => true).Take(take).Skip(skip).ToList();
        }       
        /// <summary>
        /// Add a register in a collection, specified in TEntity class
        /// </summary>
        /// <param name="entity">model to insert</param>
        /// <returns>returns the register inserted</returns>
        public TEntity Add(TEntity entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        public virtual TEntity FindById(object id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
