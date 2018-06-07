using System.Collections.Generic;
using Common.BusinessContracts;
using Common.DataAccessContracts;
using Common.Model;
using SinsajoServices.Common.Exceptions;

namespace Business
{
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

        private Address GetAddressName(string idDepartment, string idDistrict, string idProvince)
        {
            var department = _departmentRepository.FindById(idDepartment);
            var district = _districtRepository.FindById(idDistrict);
            var province = _provinceRepository.FindById(idProvince);

            if (department == null)
                throw new AppException("Department is not valid.");
            if (district == null)
                throw new AppException("District is not valid.");
            if (province == null)
                throw new AppException("Province is not valid.");

            if (province.IdDepartment != department.Id)
                throw new AppException("Province doesn't belong to selected department");
            if (province.Id != district.IdProvince)
                throw new AppException("District doesn't belong to selected province");

            return new Address
            {
                Department = department.Name,
                District = district.Name,
                Province = province.Name
            };
        }

        public Police Add(Police entity)
        {
            entity.Address = GetAddressName(entity.IdDepartment, entity.IdDistrict, entity.IdProvince);            
            entity.EndDate = entity.StartDate.Value.AddYears(1);            
            return _policeRepository.Add(entity);
        }

        public Police FindById(object id)
        {
            return _policeRepository.FindById(id);
        }

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
