using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Driver;

namespace DataAccess
{
    /// <summary>
    /// Class that access department repository in mongo
    /// </summary>
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Construct Department Repository
        /// </summary>
        /// <param name="mongoClient">Inject mongo client</param>
        public DepartmentRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }
        /// <summary>
        /// Get an specified department by id
        /// </summary>
        /// <param name="id">department id to search</param>
        /// <returns>Null if not found or department full object if match</returns>
        public override Department FindById(object id)
        {
            return Collection.Find(d => d.Id.Equals(id)).FirstOrDefault();
        }
    }
}
