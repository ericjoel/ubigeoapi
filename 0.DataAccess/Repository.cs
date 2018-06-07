using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Common.DataAccessContracts;
using MongoDB.Driver;
using System.Linq;

namespace DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMongoClient _client;
        private IMongoDatabase _mongoDataBase;
        protected IMongoCollection<TEntity> Collection;

        public Repository(IMongoClient mongoClient)
        {
            _client = mongoClient;
            _mongoDataBase = mongoClient.GetDatabase("PoliceStore");
            Collection = _mongoDataBase.GetCollection<TEntity>(typeof(TEntity).Name);            
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection.Find(_ => true).ToEnumerable();
        }

        public IEnumerable<TEntity> PageAll(int skip, int take)
        {
            return Collection.AsQueryable().Where(_ => true).Take(take).Skip(skip).ToList();
        }       

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
