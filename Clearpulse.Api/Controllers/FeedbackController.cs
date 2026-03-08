using Clearpulse.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clearpulse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("{publicId}")]
        public async Task<IActionResult> Submit(Guid publicId, [FromBody] SubmitFeedbackRequest request)
        {
            await _feedbackService.SubmitFeedbackAsync(publicId, request.Content);
            return Ok();
        }

        [HttpGet("{secretToken}")]
        public async Task<IActionResult> List(Guid secretToken)
        {
            var feedbacks = await _feedbackService.GetFeedbackForPulseAsync(secretToken);
            return Ok(feedbacks);
        }
    }

    public record SubmitFeedbackRequest(string Content);
}
