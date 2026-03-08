using Clearpulse.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clearpulse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PulseController : ControllerBase
    {
        private readonly IPulseService _pulseService;

        public PulseController(IPulseService pulseService)
        {
            _pulseService = pulseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePulseRequest request)
        {
            var token = await _pulseService.CreatePulseAsync(request.Title);
            return Ok(new { SecretToken = token });
        }

        [HttpGet("{secretToken}")]
        public async Task<IActionResult> Get(Guid secretToken)
        {
            var pulse = await _pulseService.GetPulseDetailsAsync(secretToken);
            if (pulse == null) return NotFound();
            return Ok(pulse);
        }

        [HttpGet("public/{publicId}")]
        public async Task<IActionResult> GetPublic(Guid publicId)
        {
            var pulse = await _pulseService.GetPublicPulseAsync(publicId);
            if (pulse == null) return NotFound();
            return Ok(pulse);
        }
    }

    public record CreatePulseRequest(string Title);
}
