using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewMe.Data.Models;
using ReviewMe.Logic.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace ReviewMe.API.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService) {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews([FromQuery] int? page, [FromQuery] int? limit)
        {
            try
            {
                return Ok(await _reviewService.GetReviews(page, limit));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid id)
        {
            try
            {
                await _reviewService.DeleteReview(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            try
            {
                return Ok(await _reviewService.AddReview(review));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
