using Common.Model;
using System.Collections.Generic;

namespace Common.DataAccessContracts
{
    /// <summary>
    /// Inherit IRepository and can specified get specifis methods
    /// </summary>
    public interface IDistrictRepository : IRepository<District>
    {
        /// <summary>
        /// Get districts by a specified province
        /// </summary>
        /// <param name="idProvince">province id to get districts</param>
        /// <returns>all districts of a province</returns>
        IEnumerable<District> GetByIdProvince(string idProvince);
    }
}
