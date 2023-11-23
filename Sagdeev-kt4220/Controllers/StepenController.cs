using Microsoft.AspNetCore.Mvc;
using Sagdeev_kt4220.Database;
using Sagdeev_kt4220.Filters;
using Sagdeev_kt4220.Models;
using Sagdeev_kt4220.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Sagdeev_kt4220.Controllers
{
    [ApiController]
    [Route("controller")]

    public class StepenController : Controller
    {
        private readonly ILogger<StepenController> _logger;
        private readonly IStepenService _stepenService;
        private PrepodDbcontext _context;

        public StepenController(ILogger<StepenController> logger, IStepenService stepenService, PrepodDbcontext context)
        {
            _logger = logger;
            _stepenService = stepenService;
            _context = context;
        }

        [HttpPost(Name = "GetPrepodsByStepen")]
        public async Task<IActionResult> GetPrepodsByStepenAsync(PrepodStepenFilter filter, CancellationToken cancellationToken = default)
        {
            var stepen = await _stepenService.GetPrepodsByStepenAsync(filter, cancellationToken);

            return Ok(stepen);
        }

        [HttpPost("AddStepen", Name = "AddStepen")]
        public IActionResult CreateStepen([FromBody] Stepen stepen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stepen.Add(stepen);
            _context.SaveChanges();
            return Ok(stepen);
        }

        [HttpPut("EditStepen")]
        public IActionResult UpdateStepen(string name_stepen, [FromBody] Stepen updatedStepen)
        {
            var existingStepen = _context.Stepen.FirstOrDefault(g => g.StepenName == name_stepen);

            if (existingStepen == null)
            {
                return NotFound();
            }

            existingStepen.StepenName = updatedStepen.StepenName;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteStepen")]
        public IActionResult DeleteStepen(string name_stepen, Stepen updatedDegree)
        {
            var existingStepen = _context.Stepen.FirstOrDefault(g => g.StepenName == name_stepen);

            if (existingStepen == null)
            {
                return NotFound();
            }
            _context.Stepen.Remove(existingStepen);
            _context.SaveChanges();

            return Ok();
        }
    }
}