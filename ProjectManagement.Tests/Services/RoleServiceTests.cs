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
    public class RoleServiceTests
    {
        private readonly Mock<IRoleRepository> _roleRepositoryMock = new Mock<IRoleRepository>();
        private readonly IRolesService _service;

        public RoleServiceTests()
        {
            
            _service = new RolesService(_roleRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var roleDto = new RoleDto
            {
                Name = "Admin"
            };

            // Act
            await _service.SaveAsync(roleDto);

            // Assert
            _roleRepositoryMock.Verify(x => x.SaveAsync(roleDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _roleRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _roleRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidRoleId_ThenReturnRoleDto(int roleId)
        {
            // Arrange
            var roleDto = new RoleDto
            {
                Name = "User"
            };

            _roleRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(roleId))))
                .ReturnsAsync(roleDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(roleId);

            // Assert
            _roleRepositoryMock.Verify(x => x.GetByIdAsync(roleId), Times.Once());
            Assert.That(result, Is.EqualTo(roleDto));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidRoleId_ThenReturnNull(int roleId)
        {
            // Arrange
            RoleDto defaultRoleDto = null;
            _roleRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(roleId))))
                .ReturnsAsync(defaultRoleDto);

            // Act
            var result = await _service.GetByIdIfExistsAsync(roleId);

            // Assert
            _roleRepositoryMock.Verify(x => x.GetByIdAsync(roleId), Times.Once());
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            // Arrange
            var roleDto = new RoleDto
            {
                Name = "Manager"
            };

            _roleRepositoryMock.Setup(s => s.SaveAsync(It.Is<RoleDto>(x => x.Equals(roleDto))))
                .Verifiable();

            // Act
            await _service.SaveAsync(roleDto);

            // Assert
            _roleRepositoryMock.Verify(x => x.SaveAsync(roleDto), Times.Once());
        }
    }
}
