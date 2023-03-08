using MedHelp.Services;
using MedHelp.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedHelp.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ITokenService _tokenService;
        private readonly string _headerName;

        public PatientController(IPatientService patientService, ITokenService tokenService, IConfiguration configuration)
        {
            _patientService = patientService;
            _tokenService = tokenService;
            _headerName = configuration.GetSection("HeaderName").Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatients()
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.GetPatients();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.GetPatient(id);
        }

        [HttpGet("tolon/{id}")]
        public async Task<ActionResult<List<Tolon>>> GetTolones(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.GetTolones(id);
        }

        [HttpGet("reception/{id}")]
        public async Task<ActionResult<List<Reception>>> GetReceptions(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.GetReception(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeletePatient(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.DeletePatient(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPatient(Patient patient)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.AddPatient(patient);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdatePatient(Patient patient)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.UpdatePatient(patient);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Patient>>> Search(string search)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _patientService.Search(search);
        }
    }
}
