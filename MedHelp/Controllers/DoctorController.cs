using MedHelp.Services;
using MedHelp.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedHelp.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ITokenService _tokenService;
        private readonly string _headerName;

        public DoctorController(IDoctorService doctorService, ITokenService tokenService, IConfiguration configuration)
        {
            _doctorService = doctorService;
            _tokenService = tokenService;
            _headerName = configuration.GetSection("HeaderName").Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
               return Unauthorized();

            return await _doctorService.GetDoctors();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddDoctor(Doctor doctor)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.AddDoctor(doctor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteDoctor(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.DeleteDoctor(id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateDoctor(Doctor doctor)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.UpdateDoctor(doctor);
        }

        [HttpGet("tolon/{id}")]
        public async Task<ActionResult<List<Tolon>>> GetTolones(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.GetTolones(id);
        }

        [HttpPost("tolon")]
        public async Task<ActionResult<int>> AddTolon(Tolon tolon)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.AddTolon(tolon);
        }

        [HttpDelete("tolon/{id}")]
        public async Task<ActionResult<int>> DeleteTolon(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.DeleteTolon(id);
        }

        [HttpGet("tolon/tolonId/{id}")]
        public async Task<ActionResult<Tolon>> GetTolon(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.GetTolon(id);
        }

        [HttpPost("reception")]
        public async Task<ActionResult<int>> AddReception(Reception reception)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.AddReception(reception);
        }

        [HttpGet("reception/{id}")]
        public async Task<ActionResult<List<Reception>>> GetReceptions(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _doctorService.GetReception(id);
        }
    }
}
