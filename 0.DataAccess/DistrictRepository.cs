using System.Collections.Generic;
using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Driver;

namespace DataAccess
{
    /// <summary>
    /// Class that access district repository in mongo
    /// </summary>
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        /// <summary>
        /// Construct district repository
        /// </summary>
        /// <param name="mongoClient">Inject mongloclient</param>
        public DistrictRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        /// <summary>
        /// Find district by an specified id
        /// </summary>
        /// <param name="id">the id to search</param>
        /// <returns>the district search</returns>
        public override District FindById(object id)
        {
            return Collection.Find(d => d.Id.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// Get all district by an specified province
        /// </summary>
        /// <param name="idProvince">id to search</param>
        /// <returns>The list of district than match with idprovince</returns>
        public IEnumerable<District> GetByIdProvince(string idProvince)
        {
            return Collection.Find(p => p.IdProvince.Equals(idProvince)).Sort("{ name: 1 }").ToEnumerable();
        }
    }
}
