using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Driver;

namespace DataAccess
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public override Department FindById(object id)
        {
            return Collection.Find(d => d.Id.Equals(id)).FirstOrDefault();
        }
    }
}
