using SwaggerCRUDWebAPI.Data;
using SwaggerCRUDWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwaggerCRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertDataController : ControllerBase
    {
        private IDAL _data;

        public CertDataController(IDAL context)
        {
            _data = context;
        }

        // GET: api/<CertDataController>
        [HttpGet]
        public IEnumerable<Certification> Get()
        {
            var certs = new List<Certification>();
            certs = _data.ListCertfications();

            return certs;
        }

        // GET api/<CertDataController>/5
        [HttpGet("{code}")]
        public Certification Get(string code)
        {


            var cert = _data.GetCertfication(code);


            return cert;
        }

        // POST api/<CertDataController>
        [HttpPost]
        public IActionResult Post([FromBody] Certification cert)
        {
            _data.Save(cert);

            return Ok();
        }

        // PUT api/<CertDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Certification cert)
        {
            _data.Update(cert);
        }

        // DELETE api/<CertDataController>/5
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            var cert = _data.GetCertfication(code);
            if (cert == null)
            {
                return NotFound(); // Returns HTTP 404
            }
            _data.Delete(code);

            return NoContent();
        }
    }
}
