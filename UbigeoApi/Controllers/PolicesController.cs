using Common.BusinessContracts;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UbigeoApi.Controllers
{
    public class PolicesController : ApiController
    {
        private IPoliceManager _policeManager;

        public PolicesController(IPoliceManager policeManager)
        {
            _policeManager = policeManager;
        }

        // GET api/polices
        public IEnumerable<Police> Get()
        {
            return _policeManager.GetAll();
        }

        // GET api/polices
        public HttpResponseMessage Get(string id)
        {
            var province = _policeManager.FindById(id);
            if (province == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, province);
        }

        // POST api/polices
        public HttpResponseMessage Post([FromBody]Police police)
        {
            if (ModelState.IsValid)
            {
                var policeInserted = _policeManager.Add(police);
                return Request.CreateResponse(HttpStatusCode.OK, policeInserted);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}
