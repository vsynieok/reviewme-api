using Moq;
using NUnit.Framework;
using ReviewMe.Data;
using ReviewMe.Data.Models;
using ReviewMe.Data.Repositories.Abstractions;
using ReviewMe.Logic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.Tests.Services
{
    [TestFixture]
    public class ReviewServiceTests
    {
        private Mock<IRepository<Review>> _repository;
        private ReviewService _service;

        private Review GetSampleReview()
        {
            return new Review
            {
                Id = Guid.Empty,
                Name = "Name",
                Comment = "Comment",
                Rating = 5,
                LastModified = DateTime.UtcNow,
            };
        }

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IRepository<Review>>();
            _service = new ReviewService(_repository.Object);
        }

        [Test]
        public async Task AddReview_Success_ReturnsReview()
        {
            _repository.Setup(r => r.Create(It.IsAny<Review>())).ReturnsAsync(GetSampleReview());

            var result = await _service.AddReview(It.IsAny<Review>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Review>(result);
            _repository.Verify(r => r.Create(It.IsAny<Review>()), Times.Once);
        }

        [Test]
        public async Task DeleteReview_Success_Void()
        {
            await _service.DeleteReview(Guid.Empty);

            _repository.Verify(r => r.Delete(Guid.Empty), Times.Once);
        }

        [Test]
        public async Task GetReviews_Success_ReturnsReviews()
        {
            _repository.Setup(r => r.ReadWithPagination(4, 2)).ReturnsAsync(new EntitySet<Review>());

            var result = await _service.GetReviews(4, 2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<EntitySet<Review>>(result);
            _repository.Verify(r => r.ReadWithPagination(4, 2), Times.Once);
        }
    }
}
