using Common.BusinessContracts;
using Common.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace UbigeoApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AddressController : ApiController
    {
        private IUbigeoManager _ubigeoManager;

        public AddressController(IUbigeoManager ubigeoManager)
        {
            _ubigeoManager = ubigeoManager;
        }

        [Route("api/address/provinces/{idDepartment}")]
        [HttpGet]
        public HttpResponseMessage GetProvincesByIdDepartment(string idDepartment)
        {
            var provinces = _ubigeoManager.GetProvinces(idDepartment);
            if (provinces == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, provinces);
        }

        [Route("api/address/districts/{idProvince}")]
        [HttpGet]
        public HttpResponseMessage GetDistricts(string idProvince)
        {
            var districts = _ubigeoManager.GetDistricts(idProvince);
            if (districts == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, districts);
        }

        [Route("api/address/departments")]
        [HttpGet]
        public HttpResponseMessage GetDepartments()
        {
            var departments = _ubigeoManager.GetDepartments();
            if (departments == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }
    }
}
