using System.Collections.Generic;
using Common.BusinessContracts;
using Common.DataAccessContracts;
using Common.Model;

namespace Business
{
    /// <summary>
    /// Manage all events about ubigeo
    /// </summary>
    public class UbigeoManager : IUbigeoManager
    {
        private IProvinceRepository _provinceRepository;
        private IDistrictRepository _districtRepository;
        private IDepartmentRepository _departmentRepository;

        public UbigeoManager(IProvinceRepository provinceRepository
            ,IDistrictRepository districtRepository
            ,IDepartmentRepository departmentRepository)
        {
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Get all deparments
        /// </summary>
        /// <returns>List of departments</returns>
        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }

        /// <summary>
        /// Get all districts by an specified province
        /// </summary>
        /// <param name="idProvince">province id</param>
        /// <returns>All districts of a province</returns>
        public IEnumerable<District> GetDistricts(string idProvince)
        {
            return _districtRepository.GetByIdProvince(idProvince);
        }

        /// <summary>
        /// get provinces by an specified department
        /// </summary>
        /// <param name="idDepartment">department id</param>
        /// <returns>All Provinces of a Department</returns>
        public IEnumerable<Province> GetProvinces(string idDepartment)
        {
            return _provinceRepository.GetByIdDepartment(idDepartment);
        }
    }
}
