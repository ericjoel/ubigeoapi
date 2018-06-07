using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Driver;

namespace DataAccess
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public override District FindById(object id)
        {
            return Collection.Find(d => d.Id.Equals(id)).FirstOrDefault();
        }
    }
}
