using Common.BusinessContracts;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace UbigeoApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
            var police = _policeManager.FindById(id);
            if (police == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, police);
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
