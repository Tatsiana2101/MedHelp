using MedHelp.Services;
using MedHelp.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedHelp.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ITokenService _tokenService;
        private readonly string _headerName;

        public CommentController(ICommentService commentService, ITokenService tokenService, IConfiguration configuration)
        {
            _commentService = commentService;
            _tokenService = tokenService;
            _headerName = configuration.GetSection("HeaderName").Value;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddComment(Comment comment)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _commentService.AddComment(comment);
        }

        [HttpGet("doctor/{id}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByDoctor(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _commentService.GetCommentsByDoctor(id);
        }

        [HttpGet("patient/{id}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByPatient(int id)
        {
            if (!(await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString())))
                return Unauthorized();

            return await _commentService.GetCommentsByPatient(id);
        }
    }
}
