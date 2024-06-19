using Moq;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using ProjectManagement.Services;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Shared.Dtos;

namespace ProjectManagement.Tests.Services
{
    public class ProjectsServiceTests
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock = new Mock<IProjectRepository>();
        private readonly Mock<IUsersService> _usersServiceMock = new Mock<IUsersService>();
        private readonly IProjectsService _service;

        public ProjectsServiceTests()
        {
            _service = new ProjectsService(_projectRepositoryMock.Object, _usersServiceMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidDate_ThenSaveAsync()
        {
            //Arrange
            var projectDto = new ProjectDto
            {
                
                Name = "ProjectManagement",
                Description = "Manage projects",
                IsCompleted = true
            };
            //Act
            await _service.SaveAsync(projectDto);

            //Assert
            _projectRepositoryMock.Verify(x => x.SaveAsync(projectDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _projectRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            //Arrange

            //Act
            await _service.DeleteAsync(id);

            //Assert
            _projectRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidProjectId_ThenReturnUser(int projectId)
        {
            //Arrange
            var projectDto = new ProjectDto
            {
                Name = "ProjectManagement",
                Description = "Manage projects",
                IsCompleted = true
            };


            _projectRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(projectId))))
                .ReturnsAsync(projectDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(projectId);

            //Assert
            _projectRepositoryMock.Verify(x => x.GetByIdAsync(projectId), Times.Once());
            Assert.That(userResult == projectDto);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidProjectId_ThenReturnDefault(int projectId)
        {
            //Arrange
            var project = (ProjectDto)default;
            _projectRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(projectId))))
            .ReturnsAsync(project);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(projectId);

            //Assert
            _projectRepositoryMock.Verify(x => x.GetByIdAsync(projectId), Times.Once());
            Assert.That(userResult == project);
        }
        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var projectDto = new ProjectDto
            {
                Name = "ProjectManagement",
                Description = "Manage projects",
                IsCompleted = true
            };
            _projectRepositoryMock.Setup(s => s.SaveAsync(It.Is<ProjectDto>(x => x.Equals(projectDto))))
                .Verifiable();
            //Act
            await _service.SaveAsync(projectDto);

            //Assert
            _projectRepositoryMock.Verify(x => x.SaveAsync(projectDto), Times.Once());
        }
    }
}
