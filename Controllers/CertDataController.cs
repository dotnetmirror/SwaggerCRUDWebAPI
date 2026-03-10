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
        /// <summary>
        /// API Endpoint retrun list of certifications
        /// </summary>
        /// <returns></returns>
        // GET: api/<CertDataController>
        [HttpGet]
        public IEnumerable<Certification> Get()
        {
            var certs = new List<Certification>();
            certs = _data.ListCertfications();

            return certs;
        }
        /// <summary>
        /// return specific certifcation by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        // GET api/<CertDataController>/5
        [HttpGet("{code}")]
        public Certification Get(string code)
        {


            var cert = _data.GetCertfication(code);


            return cert;
        }
        /// <summary>
        /// To post cerftication
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST //api/certdata
        ///     {
        ///        "code": "AWSCDA",
        ///        "description": "AWS Certified Developer - Associate",
        ///        "examDate": "2026-02-03"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>

        // POST api/<CertDataController>
        [HttpPost]
        public IActionResult Post([FromBody] Certification cert)
        {
            _data.Save(cert);

            return Ok();
        }
        /// <summary>
        /// To update certfiation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cert"></param>
        // PUT api/<CertDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Certification cert)
        {
            _data.Update(cert);
        }
        /// <summary>
        /// To Delete Certification
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
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
