using Common.Model;

namespace Common.BusinessContracts
{
    /// <summary>
    /// Inherit IBaseManager and can specified get specifis methods
    /// </summary>
    public interface IPoliceManager : IBaseManager<Police>
    {
        /// <summary>
        /// Get name of district by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetNameDistrictById(string id);
        /// <summary>
        /// Get name of province by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetNameProvinceById(string id);
    }
}
