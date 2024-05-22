using Business.DTOs.Source;
using Business.Exceptions;
using Business.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeAPI.Controllers;

namespace ApiTests
{
    [TestClass]
    public class SourceControllerTests
    {
        [TestMethod]
        public async Task GivenWhenGetThenReturn()
        {
            // Arrange
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(business => business.GetAllAsync())
                .ReturnsAsync(GetTestEntities());
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.AreEqual(result.Value.Count(), 2);
        }
        [TestMethod]
        public async Task GivenEntityWhenGetByIdThenGet()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(business => business.FindAsync(entityId))
                .ReturnsAsync(GetTestEntity());
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(entityId);

            // Assert
            Assert.AreEqual(result.Value.Name, "test_2");
        }
        [TestMethod]
        public async Task GivenNoEntityWhenGetByIdThenThrow()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(business => business.FindAsync(entityId))
                .Returns(Task.FromResult<GetSourceDto>(null));
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(entityId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenNoEntityWhenDeleteThenThrow()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(entityId))
                .Throws(new NotFoundException());
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(entityId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenEntityWhenDeleteThenDelete()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(entityId))
                .Returns(Task.FromResult<GetSourceDto>(null));
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.Delete(entityId);

            // Assert
            mockBusiness.Verify(b => b.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidEntityWhenPutThenUpdate()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var entityPutDto = new PutSourceDto()
            {
                Id = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035"),
                Name = "test_1",
                SourceTypeName = "test_2"
            };
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(x => x.PutAsync(entityId, entityPutDto)).Verifiable();
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.Put(entityId, entityPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutSourceDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidEntityWhenPostThenAdd()
        {
            // Arrange
            var newEntity = new PostSourceDto()
            {
                Name = "test_1",
                SourceTypeName = "test_2"
            };
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(x => x.AddAsync(newEntity)).Verifiable();
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.Post(newEntity);

            // Assert
            mockBusiness.Verify(b => b.AddAsync(It.IsAny<PostSourceDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenInValidEntityWhenPutThenThrow()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var entityPutDto = new PutSourceDto()
            {
                Name = "test_1",
                SourceTypeName = "test_2"

            };
            var mockBusiness = new Mock<ISourceBusiness>();
            mockBusiness.Setup(x => x.PutAsync(entityId, entityPutDto)).Verifiable();
            var controller = new SourcesController(mockBusiness.Object);

            // Act
            var result = await controller.Put(entityId, entityPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutSourceDto>()), Times.Never);
            Assert.IsInstanceOfType<BadRequestResult>(result);
        }
        private List<GetSourceDto> GetTestEntities()
        {
            var entities = new List<GetSourceDto>();
            entities.Add(new GetSourceDto()
            {
                Id = Guid.NewGuid(),
                Name = "test_1",
                SourceTypeId = Guid.NewGuid(),
                SourceTypeName = "test_source_type"
            });
            entities.Add(new GetSourceDto()
            {
                Id = Guid.NewGuid(),
                Name = "test_2",
                SourceTypeId = Guid.NewGuid(),
                SourceTypeName = "test_source_type_2"
            });
            return entities;
        }

        private GetSourceDto GetTestEntity()
        {
            return new GetSourceDto()
            {
                Id = Guid.NewGuid(),
                Name = "test_2",
                SourceTypeId = Guid.NewGuid(),
                SourceTypeName = "test_source_type_2"
            };
        }
    }
}