using Moq;
using ProjectManagement.Services;
using ProjectManagement.Shared.Dtos;
using ProjectManagement.Shared.Repos.Contacts;
using ProjectManagement.Shared.Services.Contracts;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using ProjectManagement.Shared.Enums;

namespace ProjectManagement.Tests.Services
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock = new Mock<ITaskRepository>();
        private readonly ITasksService _service;

        public TaskServiceTests()
        {
            
            _service = new TasksService(_taskRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var taskDto = new TaskDto
            {
                Name = "New Task",
                Description = "Task description",
                Status = Status.Completed,
                Deadline = DateTime.Now.AddDays(10),
                ProjectId = 1,
                UserId = 1
            };

            // Act
            await _service.SaveAsync(taskDto);

            // Assert
            _taskRepositoryMock.Verify(x => x.SaveAsync(taskDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _taskRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
        }

        [Test]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            // Act
            await _service.DeleteAsync(id);

            // Assert
            _taskRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidTaskId_ThenReturnTaskDto(int taskId)
        {
            // Arrange
            var taskDto = new TaskDto
            {
                Name = "Existing Task",
                Description = "Existing task description",
                Status = Status.Completed,
                Deadline = DateTime.Now.AddDays(5),
                ProjectId = 2,
                UserId = 2
            };

            _taskRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(taskId))))
                .ReturnsAsync(taskDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(taskId);

            // Assert
            _taskRepositoryMock.Verify(x => x.GetByIdAsync(taskId), Times.Once());
            Assert.That(result, Is.EqualTo(taskDto));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidTaskId_ThenReturnNull(int taskId)
        {
            // Arrange
            TaskDto defaultTaskDto = null;
            _taskRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(taskId))))
                .ReturnsAsync(defaultTaskDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(taskId);

            // Assert
            _taskRepositoryMock.Verify(x => x.GetByIdAsync(taskId), Times.Once());
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var taskDto = new TaskDto
            {
                Name = "Updated Task",
                Description = "Updated task description",
                Status = Status.InProgress,
                Deadline = DateTime.Now.AddDays(15),
                ProjectId = 3,
                UserId = 3
            };

            _taskRepositoryMock.Setup(s => s.SaveAsync(It.Is<TaskDto>(x => x.Equals(taskDto))))
                .Verifiable();

            // Act
            await _service.SaveAsync(taskDto);

            // Assert
            _taskRepositoryMock.Verify(x => x.SaveAsync(taskDto), Times.Once());
        }
    }
}