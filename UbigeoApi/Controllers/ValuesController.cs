using Common.BusinessContracts;
using Common.DataAccessContracts;
using Common.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace UbigeoApi.Controllers
{
    public class ValuesController : ApiController
    {
        private IPoliceManager _policeManager;

        public ValuesController(IPoliceManager policeManager)
        {
            _policeManager = policeManager;
        }

        // GET api/values
        public IEnumerable<Police> Get()
        {
            return _policeManager.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
