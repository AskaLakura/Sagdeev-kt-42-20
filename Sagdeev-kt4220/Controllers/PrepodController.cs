using Microsoft.AspNetCore.Mvc;
using Sagdeev_kt4220.Filters;
using Sagdeev_kt4220.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Sagdeev_kt4220.Controllers
{
    [ApiController]
    [Route("prepod")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;

        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService)
        {
            _logger = logger;
            _prepodService = prepodService;
        }

        [HttpPost(Name = "GetPrepodsByGroup")]
        public async Task<IActionResult> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByGroupAsync(filter, cancellationToken);

            return Ok(prepod);
        }
    }
}
