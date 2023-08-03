using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewMe.Data.Models;
using ReviewMe.Logic.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace ReviewMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService) {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                return Ok(await _reviewService.GetAllReviews()); 
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
                return BadRequest();
            }
        }
    }
}
