using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess
{
    /// <summary>
    /// Class that access police repository in mongo
    /// </summary>
    public class PoliceRepository : Repository<Police>, IPoliceRepository
    {
        /// <summary>
        /// Construct police repository
        /// </summary>
        /// <param name="mongoClient">Inject mongloclient</param>
        public PoliceRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        /// <summary>
        /// Override FindById to search by objectid
        /// </summary>
        /// <param name="id">Police id to search</param>
        /// <returns>The police searched</returns>
        public override Police FindById(object id)
        {
            ObjectId policeId = new ObjectId();
            //Verify if the id passed by parameter is a valid objectid
            var result = ObjectId.TryParse(id.ToString(), out policeId);
            //if not return null, to send not found response
            if (!result)
                return null;
            return Collection.Find(p => p.Id.Equals(policeId)).FirstOrDefault();
        }
    }
}
