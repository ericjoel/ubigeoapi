using System.Collections.Generic;
using Common.DataAccessContracts;
using Common.Model;
using MongoDB.Driver;

namespace DataAccess
{
    /// <summary>
    /// Class that access province repository in mongo
    /// </summary>
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        /// <summary>
        /// Construct province repository
        /// </summary>
        /// <param name="mongoClient">Inject mongloclient</param>
        public ProvinceRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        /// <summary>
        /// Find a province by specified id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>the province searched</returns>
        public override Province FindById(object id)
        {
            return Collection.Find(p => p.Id.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// Find provinces by an specified department
        /// </summary>
        /// <param name="idDepartment">id department</param>
        /// <returns>provinces searched</returns>
        public IEnumerable<Province> GetByIdDepartment(string idDepartment)
        {
            return Collection.Find(p => p.IdDepartment.Equals(idDepartment)).Sort("{ name: 1 }").ToEnumerable();
        }
    }
}
