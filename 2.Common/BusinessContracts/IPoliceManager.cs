using Common.Model;

namespace Common.BusinessContracts
{
    public interface IPoliceManager : IBaseManager<Police>
    {
        string GetNameDistrictById(string id);
        string GetNameProvinceById(string id);
    }
}
