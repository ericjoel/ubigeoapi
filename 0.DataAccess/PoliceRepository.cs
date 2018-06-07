using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess
{
    public class PoliceRepository : Repository<Police>, IPoliceRepository
    {
        public PoliceRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public override Police FindById(object id)
        {
            ObjectId policeId = new ObjectId();
            var result = ObjectId.TryParse(id.ToString(), out policeId);
            if (!result)
                return null;
            return Collection.Find(p => p.Id.Equals(policeId)).FirstOrDefault();
        }
    }
}
