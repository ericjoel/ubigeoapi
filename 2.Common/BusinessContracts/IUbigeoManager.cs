using Common.Model;
using System.Collections.Generic;

namespace Common.BusinessContracts
{
    /// <summary>
    /// Inherit IBaseManager and can specified get specifis methods
    /// </summary>
    public interface IUbigeoManager 
    {
        /// <summary>
        /// Get all departments in DB
        /// </summary>
        /// <returns></returns>
        IEnumerable<Department> GetDepartments();
        
        /// <summary>
        /// Get all districts by an specified province
        /// </summary>
        /// <param name="idProvince">id province to get districts</param>
        /// <returns></returns>
        IEnumerable<District> GetDistricts(string idProvince);
        
        /// <summary>
        /// Get all provinces by an specified department
        /// </summary>
        /// <param name="idDepartment">id department to get provinces</param>
        /// <returns></returns>
        IEnumerable<Province> GetProvinces(string idDepartment);
    }
}
