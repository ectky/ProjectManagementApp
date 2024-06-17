using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ProjectManagement.Data;
using ProjectManagement.Data.Entities;
using ProjectManagement.Data.Repos;
using ProjectManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Test.Repos
{
    public abstract class BaseRepositoryTests<TRepository, T, TModel>
        where TRepository : BaseRepository<T, TModel>
        where T : class, IBaseEntity
        where TModel : BaseModel
    {
        private Mock<ProjectManagementDbContext> mockContext;
        private Mock<DbSet<T>> mockDbSet;
        private Mock<IMapper> mockMapper;
        private TRepository repository;

        

        [SetUp]

        public void Setup()
        {
            mockContext = new Mock<ProjectManagementDbContext>();
            mockDbSet = new Mock<DbSet<T>>();
            mockMapper = new Mock<IMapper>();
            repository = new Mock<TRepository>(mockContext.Object, mockMapper.Object)
            { CallBase = true }.Object;
        }

        [Test]
        public void MapToModel_ValidEntity_ReturnsMappedModel()
        {
            // Arrange 
            var entity = new Mock<T>();
            var model = new Mock<TModel>();
            mockMapper.Setup(m => m.Map<TModel>(entity.Object)).Returns(model.Object);

            // Act
            var result = repository.MapToModel(entity.Object);

            // Assert
            Assert.That(result, Is.EqualTo(model.Object));
        }
    }
}

