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
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly IUsersService _service;

        public UserServiceTests()
        {
            
            _service = new UsersService(_userRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            
            var userDto = new UserDto
            {
                Username = "DarkMaster",
                Email = "ivbussbvusf",
                Password = "666777",
                FirstName = "Bobo",
                LastName = "Kovan",
                RoleId = 1
            };

            // Act
            await _service.SaveAsync(userDto);

            // Assert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _userRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _userRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidTaskId_ThenReturnTaskDto(int userId)
        {
            var userDto = new UserDto
            {
                Username = "DarkMaster",
                Email = "ivbussbvusf",
                Password = "666777",
                FirstName = "Bobo",
                LastName = "Kovan",
                RoleId = 1
            };

            _userRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(userDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(userId);

            
            _userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once());
            Assert.That(result, Is.EqualTo(userDto));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidTaskId_ThenReturnNull(int userId)
        {
            // Arrange
            UserDto defaultUserDto = null;
            _userRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(defaultUserDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(userId);

            // Assert
            _userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once());
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            var userDto = new UserDto
            {
                Username = "DarkMaster",
                Email = "ivbussbvusf",
                Password = "666777",
                FirstName = "Bobo",
                LastName = "Kovan",
                RoleId = 1
            };

            _userRepositoryMock.Setup(s => s.SaveAsync(It.Is<UserDto>(x => x.Equals(userDto))))
                .Verifiable();

            // Act
            await _service.SaveAsync(userDto);

            // Assert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once());
        }
    }
}
