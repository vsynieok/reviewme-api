using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReviewMe.API.Controllers;
using ReviewMe.Data.Models;
using ReviewMe.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.Tests.Controllers
{
    [TestFixture]
    public class ReviewsControllerTests
    {
        private Mock<IReviewService> _reviewService;
        private ReviewsController _controller;

        [SetUp]
        public void SetUp()
        {
            _reviewService = new Mock<IReviewService>();
            _controller = new ReviewsController(_reviewService.Object);

        }

        [Test]
        public async Task GetReviews_HasArguments_ReturnsOk()
        {
            _reviewService.Setup(s => s.GetReviews(4, 2)).ReturnsAsync(It.IsAny<EntitySet<Review>>);

            var result = await _controller.GetReviews(4, 2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetReviews_HasNoArguments_ReturnsOk()
        {
            _reviewService.Setup(s => s.GetReviews(null, null)).ReturnsAsync(It.IsAny<EntitySet<Review>>);

            var result = await _controller.GetReviews(null, null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetReviews_GoesWrong_ReturnsInternalServerError()
        {
            _reviewService.Setup(s => s.GetReviews(4, 2)).ThrowsAsync(new InvalidOperationException());

            var result = await _controller.GetReviews(4, 2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.That((result as StatusCodeResult).StatusCode, Is.EqualTo(500));
        }

        [Test]
        public async Task DeleteReview_Success_ReturnsOk()
        {
            var result = await _controller.DeleteReview(Guid.Empty);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
            _reviewService.Verify(s => s.DeleteReview(Guid.Empty), Times.Once);
        }

        [Test]
        public async Task DeleteReview_NotFound_ReturnsNotFound()
        {
            _reviewService.Setup(s => s.DeleteReview(Guid.Empty)).ThrowsAsync(new InvalidOperationException());

            var result = await _controller.DeleteReview(Guid.Empty);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
            _reviewService.Verify(s => s.DeleteReview(Guid.Empty), Times.Once);
        }

        [Test]
        public async Task DeleteReview_GoesWrong_ReturnsInternalServerError()
        {
            _reviewService.Setup(s => s.DeleteReview(Guid.Empty)).ThrowsAsync(new Exception());

            var result = await _controller.DeleteReview(Guid.Empty);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.That((result as StatusCodeResult).StatusCode, Is.EqualTo(500));
            _reviewService.Verify(s => s.DeleteReview(Guid.Empty), Times.Once);
        }

        [Test]
        public async Task AddReview_Success_ReturnsOk()
        {
            _reviewService.Setup(s => s.AddReview(It.IsAny<Review>())).ReturnsAsync(It.IsAny<Review>());

            var result = await _controller.AddReview(It.IsAny<Review>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            _reviewService.Verify(s => s.AddReview(It.IsAny<Review>()), Times.Once);
        }

        [Test]
        public async Task AddReview_GoesWrong_ReturnsInternalServerError()
        {
            _reviewService.Setup(s => s.AddReview(It.IsAny<Review>())).ThrowsAsync(new Exception());

            var result = await _controller.AddReview(It.IsAny<Review>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.That((result as StatusCodeResult).StatusCode, Is.EqualTo(500));
            _reviewService.Verify(s => s.AddReview(It.IsAny<Review>()), Times.Once);
        }
    }
}
