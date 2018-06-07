using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Driver;

namespace DataAccess
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public override Province FindById(object id)
        {
            return Collection.Find(p => p.Id.Equals(id)).FirstOrDefault();
        }
    }
}
