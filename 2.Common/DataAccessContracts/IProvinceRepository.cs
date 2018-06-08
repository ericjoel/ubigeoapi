using Common.Model;
using System.Collections.Generic;

namespace Common.DataAccessContracts
{
    /// <summary>
    /// Inherit IRepository and can specified get specifis methods
    /// </summary>
    public interface IProvinceRepository : IRepository<Province>
    {
        /// <summary>
        /// Get provinces by a specified department
        /// </summary>
        /// <param name="idDepartment">department id to get provinces</param>
        /// <returns>all provinces of a departments</returns>
        IEnumerable<Province> GetByIdDepartment(string idDepartment);
    }
}
