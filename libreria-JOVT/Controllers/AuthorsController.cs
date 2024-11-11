using libreria_JOVT.Data.Models;
using libreria_JOVT.Data.Models.Services;
using libreria_JOVT.Data.Services;
using libreria_JOVT.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreria_JOVT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
    }
}
