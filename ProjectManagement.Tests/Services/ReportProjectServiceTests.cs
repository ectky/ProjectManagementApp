using Moq;
using ProjectManagement.Services;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Services
{
    public class ReportProjectServiceTests
    {
        private readonly Mock<IReportProjectRepository> _reportProjectRepositoryMock = new Mock<IReportProjectRepository>();
        private readonly Mock<IReportsService> _reportServiceMock = new Mock<IReportsService>();
        private readonly Mock<IProjectsService> _projectsServiceMock = new Mock<IProjectsService>();
        private readonly IReportProjectsService _service;

        public ReportProjectServiceTests()
        {
            _service = new ReportProjectsService(
                _reportProjectRepositoryMock.Object,
                _reportServiceMock.Object,
                _projectsServiceMock.Object
            );
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var reportProjectDto = new ReportProjectDto(1, 1) // Use the constructor with required arguments
            {
                Report = new ReportDto { /* Initialize properties if needed */ },
                Project = new ProjectDto { /* Initialize properties if needed */ }
            };

            // Act
            await _service.SaveAsync(reportProjectDto);

            // Assert
            _reportProjectRepositoryMock.Verify(x => x.SaveAsync(reportProjectDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _reportProjectRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            // Act
            await _service.DeleteAsync(id);

            // Assert
            _reportProjectRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidReportProjectId_ThenReturnReportProjectDto(int reportProjectId)
        {
            // Arrange
            var reportProjectDto = new ReportProjectDto(1, reportProjectId)
            {
                Report = new ReportDto { /* Initialize properties if needed */ },
                Project = new ProjectDto { /* Initialize properties if needed */ }
            };

            _reportProjectRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(reportProjectId))))
                .ReturnsAsync(reportProjectDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(reportProjectId);

            // Assert
            _reportProjectRepositoryMock.Verify(x => x.GetByIdAsync(reportProjectId), Times.Once());
            Assert.That(result, Is.EqualTo(reportProjectDto));
        }

        [Theory]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidProjectId_ThenReturnDefault(int reportProjectId)
        {
            // Arrange
            ReportProjectDto defaultReportProjectDto = null;
            _reportProjectRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(reportProjectId))))
                .ReturnsAsync(defaultReportProjectDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(reportProjectId);

            // Assert
            _reportProjectRepositoryMock.Verify(x => x.GetByIdAsync(reportProjectId), Times.Once());
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var reportProjectDto = new ReportProjectDto(1, 1)
            {
                Report = new ReportDto { /* Initialize properties if needed */ },
                Project = new ProjectDto { /* Initialize properties if needed */ }
            };

            _reportProjectRepositoryMock.Setup(s => s.SaveAsync(It.Is<ReportProjectDto>(x => x.Equals(reportProjectDto))))
                .Verifiable();

            // Act
            await _service.SaveAsync(reportProjectDto);

            // Assert
            _reportProjectRepositoryMock.Verify(x => x.SaveAsync(reportProjectDto), Times.Once());
        }
    }
}
