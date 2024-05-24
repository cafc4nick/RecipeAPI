using Business.DTOs.Source;
using Business.DTOs.UserType;
using Business.Exceptions;
using Business.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeAPI.Controllers;

namespace ApiTests
{
    [TestClass]
    public class UserTypeControllerTests
    {
        [TestMethod]
        public async Task GivenWhenGetThenReturn()
        {
            // Arrange
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(business => business.GetAllAsync())
                .ReturnsAsync(GetTestEntities());
            var controller = new UserTypesController(mockBusiness.Object);

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
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(business => business.FindAsync(entityId))
                .ReturnsAsync(GetTestEntity());
            var controller = new UserTypesController(mockBusiness.Object);

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
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(business => business.FindAsync(entityId))
                .Returns(Task.FromResult<GetUserTypeDto>(null));
            var controller = new UserTypesController(mockBusiness.Object);

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
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(entityId))
                .Throws(new NotFoundException());
            var controller = new UserTypesController(mockBusiness.Object);

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
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(entityId))
                .Returns(Task.FromResult<GetUserTypeDto>(null));
            var controller = new UserTypesController(mockBusiness.Object);

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
            var entityPutDto = new PutUserTypeDto()
            {
                Id = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035"),
                Name = "test_1",
            };
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(x => x.PutAsync(entityId, entityPutDto)).Verifiable();
            var controller = new UserTypesController(mockBusiness.Object);

            // Act
            var result = await controller.Put(entityId, entityPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutUserTypeDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidEntityWhenPostThenAdd()
        {
            // Arrange
            var newEntity = new PostUserTypeDto()
            {
                Name = "test_1",
            };
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(x => x.AddAsync(newEntity)).Verifiable();
            var controller = new UserTypesController(mockBusiness.Object);

            // Act
            var result = await controller.Post(newEntity);

            // Assert
            mockBusiness.Verify(b => b.AddAsync(It.IsAny<PostUserTypeDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenInValidEntityWhenPutThenThrow()
        {
            // Arrange
            var entityId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var entityPutDto = new PutUserTypeDto()
            {
                Name = "test_1",

            };
            var mockBusiness = new Mock<IUserTypeBusiness>();
            mockBusiness.Setup(x => x.PutAsync(entityId, entityPutDto)).Verifiable();
            var controller = new UserTypesController(mockBusiness.Object);

            // Act
            var result = await controller.Put(entityId, entityPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutUserTypeDto>()), Times.Never);
            Assert.IsInstanceOfType<BadRequestResult>(result);
        }
        private List<GetUserTypeDto> GetTestEntities()
        {
            var entities = new List<GetUserTypeDto>();
            entities.Add(new GetUserTypeDto()
            {
                Id = Guid.NewGuid(),
                Name = "test_1",
            });
            entities.Add(new GetUserTypeDto()
            {
                Id = Guid.NewGuid(),
                Name = "test_2",
            });
            return entities;
        }

        private GetUserTypeDto GetTestEntity()
        {
            return new GetUserTypeDto()
            {
                Id = Guid.NewGuid(),
                Name = "test_2",
            };
        }
    }
}