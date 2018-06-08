using System.Collections.Generic;
using Common.BusinessContracts;
using Common.DataAccessContracts;
using Common.Model;
using SinsajoServices.Common.Exceptions;

namespace Business
{
    /// <summary>
    /// Manage all events about police
    /// </summary>
    public class PoliceManager : IPoliceManager
    {
        private IPoliceRepository _policeRepository;
        private IDepartmentRepository _departmentRepository;
        private IDistrictRepository _districtRepository;
        private IProvinceRepository _provinceRepository;

        public PoliceManager(IPoliceRepository policeRepository
            , IDepartmentRepository departmentRepository
            , IDistrictRepository districtRepository
            , IProvinceRepository provinceRepository)
        {
            _policeRepository = policeRepository;
            _departmentRepository = departmentRepository;
            _districtRepository = districtRepository;
            _provinceRepository = provinceRepository;
        }
        /// <summary>
        /// Get Address object and validate if department, province and district are valid
        /// </summary>
        /// <param name="idDepartment">Id Department</param>
        /// <param name="idDistrict">Id District</param>
        /// <param name="idProvince">Id Province</param>
        /// <returns>Address with names</returns>
        private Address GetAddressName(string idDepartment, string idDistrict, string idProvince)
        {
            var department = _departmentRepository.FindById(idDepartment);
            var district = _districtRepository.FindById(idDistrict);
            var province = _provinceRepository.FindById(idProvince);
            //if not found a department, then is invalid
            if (department == null)
                throw new AppException("Department is not valid.");
            //if not found a district, then is invalid
            if (district == null)
                throw new AppException("District is not valid.");
            //if not found a province, then is invalid
            if (province == null)
                throw new AppException("Province is not valid.");
            //Province doesn't belong department 
            if (province.IdDepartment != department.Id)
                throw new AppException("Province doesn't belong to selected department");
            //District doesn't belong province
            if (province.Id != district.IdProvince)
                throw new AppException("District doesn't belong to selected province");

            return new Address
            {
                Department = department.Name,
                District = district.Name,
                Province = province.Name
            };
        }
        /// <summary>
        /// Add an police
        /// </summary>
        /// <param name="entity">police to insert</param>
        /// <returns></returns>
        public Police Add(Police entity)
        {
            //Validate address
            entity.Address = GetAddressName(entity.IdDepartment, entity.IdDistrict, entity.IdProvince);            
            //Add a year to start date to get the end date
            entity.EndDate = entity.StartDate.Value.AddYears(1);            
            return _policeRepository.Add(entity);
        }

        /// <summary>
        /// Find a police by a specified id
        /// </summary>
        /// <param name="id">id of police</param>
        /// <returns>the police</returns>
        public Police FindById(object id)
        {
            return _policeRepository.FindById(id);
        }

        /// <summary>
        /// Get all the polices
        /// </summary>
        /// <returns>Polices in DB</returns>
        public IEnumerable<Police> GetAll()
        {
            return _policeRepository.GetAll();
        }
        
        public string GetNameDistrictById(string id)
        {
            var district = _districtRepository.FindById(id);            
            return district?.Name;
        }

        public string GetNameProvinceById(string id)
        {
            var province = _provinceRepository.FindById(id);
            return province?.Name;
        }

        public IEnumerable<Police> PageAll(int skip, int take)
        {
            return _policeRepository.PageAll(skip, take);
        }

        public void Remove(Police entity)
        {
            _policeRepository.Remove(entity);
        }

        public void Update(Police entity)
        {
            _policeRepository.Update(entity);
        }
    }
}
