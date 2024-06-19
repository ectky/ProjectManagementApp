using Moq;
using NUnit.Framework;
using ProjectManagement.Services;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Services
{
    public class ReportServiceTests
    {
        private Mock<IReportRepository> _reportRepositoryMock;
        private IReportsService _service;

        [SetUp]
        public void SetUp()
        {
            _reportRepositoryMock = new Mock<IReportRepository>();
            _service = new ReportsService(_reportRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var reportDto = CreateReportDto("Report Name", "Report Description");

            // Act
            await _service.SaveAsync(reportDto);

            // Assert
            _reportRepositoryMock.Verify(x => x.SaveAsync(reportDto), Times.Once);
        }

        [Test]
        public void WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _reportRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
        }

        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            // Act
            await _service.DeleteAsync(id);

            // Assert
            _reportRepositoryMock.Verify(x => x.DeleteAsync(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidReportId_ThenReturnReportDto(int reportId)
        {
            // Arrange
            var reportDto = CreateReportDto("Valid Report", "Valid Description");
            _reportRepositoryMock.Setup(x => x.GetByIdAsync(reportId)).ReturnsAsync(reportDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(reportId);

            // Assert
            _reportRepositoryMock.Verify(x => x.GetByIdAsync(reportId), Times.Once);
            Assert.That(result, Is.EqualTo(reportDto));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidReportId_ThenReturnDefault(int reportId)
        {
            // Arrange
            _reportRepositoryMock.Setup(s => s.GetByIdAsync(reportId)).ReturnsAsync((ReportDto)null);

            // Act
            var result = await _service.GetByIdIfExistsAsync(reportId);

            // Assert
            _reportRepositoryMock.Verify(x => x.GetByIdAsync(reportId), Times.Once);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var reportDto = CreateReportDto("Updated Report", "Updated Description");
            _reportRepositoryMock.Setup(s => s.SaveAsync(It.IsAny<ReportDto>())).Verifiable();

            // Act
            await _service.SaveAsync(reportDto);

            // Assert
            _reportRepositoryMock.Verify(x => x.SaveAsync(reportDto), Times.Once);
        }

        private ReportDto CreateReportDto(string name, string description)
        {
            return new ReportDto
            {
                Name = name,
                Description = description,
                ReportProjects = new List<ReportProjectDto>()
            };
        }
    }
}
