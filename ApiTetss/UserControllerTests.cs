using Business.DTOs.User;
using Business.Exceptions;
using Business.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeAPI.Controllers;

namespace ApiTetss
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task GivenUsersWhenGetThenReturn()
        {
            // Arrange
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(business => business.GetAllAsync())
                .ReturnsAsync(GetTestUsers());
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.AreEqual(result.Value.Count(), 2);
        }
        [TestMethod]
        public async Task GivenUserWhenGetByIdThenGet()
        {
            // Arrange
            var userId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(business => business.FindAsync(userId))
                .ReturnsAsync(GetTestUser());
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(userId);

            // Assert
            Assert.AreEqual(result.Value.UserName, "test_1");
        }
        [TestMethod]
        public async Task GivenNoUserWhenGetByIdThenThrow()
        {
            // Arrange
            var userId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(business => business.FindAsync(userId))
                .Returns(Task.FromResult<GetUserDto>(null));
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(userId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenNoUserWhenDeleteThenThrow()
        {
            // Arrange
            var userId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(userId))
                .Throws(new NotFoundException());
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(userId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenUserWhenDeleteThenDelete()
        {
            // Arrange
            var userId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(userId))
                .Returns(Task.FromResult<GetUserDto>(null));
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.Delete(userId);

            // Assert
            mockBusiness.Verify(b => b.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidUserWhenPutThenUpdate()
        {
            // Arrange
            var userId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var userPutDto = new PutUserDto()
            {
                Id = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035"),
                UserName = "test_1",
                Email = "test_1@test.com"
            };
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(x => x.PutAsync(userId, userPutDto)).Verifiable();
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.Put(userId, userPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutUserDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidUserWhenPostThenAdd()
        {
            // Arrange
            var newUser = new PostUserDto()
            {
                UserName = "test_1",
                Email = "test_1@test.com"
            };
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(x => x.AddAsync(newUser)).Verifiable();
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.Post(newUser);

            // Assert
            mockBusiness.Verify(b => b.AddAsync(It.IsAny<PostUserDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenInValidUserWhenPutThenThrow()
        {
            // Arrange
            var userId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var userPutDto = new PutUserDto()
            {
                UserName = "test_1",
                Email = "test_1@test.com"

            };
            var mockBusiness = new Mock<IUserBusiness>();
            mockBusiness.Setup(x => x.PutAsync(userId, userPutDto)).Verifiable();
            var controller = new UsersController(mockBusiness.Object);

            // Act
            var result = await controller.Put(userId, userPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutUserDto>()), Times.Never);
            Assert.IsInstanceOfType<BadRequestResult>(result);
        }
        private List<GetUserDto> GetTestUsers()
        {
            var users = new List<GetUserDto>();
            users.Add(new GetUserDto()
            {
                Id = Guid.NewGuid(),
                UserName = "test_1",
                Password = "blah",
                Email = "test_1@test.com"
            });
            users.Add(new GetUserDto()
            {
                Id = Guid.NewGuid(),
                UserName = "test_2",
                Password = "blah",
                Email = "test_2@test.com"
            });
            return users;
        }

        private GetUserDto GetTestUser()
        {
            return new GetUserDto()
            {
                Id = Guid.NewGuid(),
                UserName = "test_1",
                Password = "blah",
                Email = "test_1@test.com"
            };
        }
    }
}