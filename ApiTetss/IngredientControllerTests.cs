using Business.DTOs.Ingredient;
using Business.Exceptions;
using Business.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeAPI.Controllers;

namespace ApiTetss
{
    [TestClass]
    public class IngredientControllerTests
    {
        [TestMethod]
        public async Task GivenIngredientsWhenGetThenReturn()
        {
            // Arrange
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(business => business.GetAllAsync())
                .ReturnsAsync(GetTestIngredients());
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.AreEqual(result.Value.Count(), 2);
        }
        [TestMethod]
        public async Task GivenIngredientWhenGetByIdThenGet()
        {
            // Arrange
            var ingredientId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(business => business.FindAsync(ingredientId))
                .ReturnsAsync(GetTestIngredient());
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(ingredientId);

            // Assert
            Assert.AreEqual(result.Value.Name, "test_2");
        }
        [TestMethod]
        public async Task GivenNoIngredientWhenGetByIdThenThrow()
        {
            // Arrange
            var ingredientId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(business => business.FindAsync(ingredientId))
                .Returns(Task.FromResult<GetIngredientDto>(null));
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(ingredientId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenNoIngredientWhenDeleteThenThrow()
        {
            // Arrange
            var ingredientId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(ingredientId))
                .Throws(new NotFoundException());
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.GetOne(ingredientId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenIngredientWhenDeleteThenDelete()
        {
            // Arrange
            var ingredientId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(ingredientId))
                .Returns(Task.FromResult<GetIngredientDto>(null));
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.Delete(ingredientId);

            // Assert
            mockBusiness.Verify(b => b.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidIngredientWhenPutThenUpdate()
        {
            // Arrange
            var ingredientId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var ingredientPutDto = new PutIngredientDto()
            {
                UserId = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                Id = ingredientId,
                Name = "test"
            };
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(x => x.PutAsync(ingredientId, ingredientPutDto)).Verifiable();
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.Put(ingredientId, ingredientPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutIngredientDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidIngredientWhenPostThenAdd()
        {
            // Arrange
            var newIngredient = new PostIngredientDto()
            {
                UserId = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                Name = "test"
            };
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(x => x.AddAsync(newIngredient)).Verifiable();
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.Post(newIngredient);

            // Assert
            mockBusiness.Verify(b => b.AddAsync(It.IsAny<PostIngredientDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenInValidIngredientWhenPutThenThrow()
        {
            // Arrange
            var ingredientId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var ingredientPutDto = new PutIngredientDto()
            {
                UserId = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Name = "test"
            };
            var mockBusiness = new Mock<IIngredientBusiness>();
            mockBusiness.Setup(x => x.PutAsync(ingredientId, ingredientPutDto)).Verifiable();
            var controller = new IngredientsController(mockBusiness.Object);

            // Act
            var result = await controller.Put(ingredientId, ingredientPutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutIngredientDto>()), Times.Never);
            Assert.IsInstanceOfType<BadRequestResult>(result);
        }
        private List<GetIngredientDto> GetTestIngredients()
        {
            var ingredients = new List<GetIngredientDto>();
            ingredients.Add(new GetIngredientDto()
            {
                Id = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "test_1"
            });
            ingredients.Add(new GetIngredientDto()
            {
                Id = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "test_2"
            });
            return ingredients;
        }

        private GetIngredientDto GetTestIngredient()
        {
            return new GetIngredientDto()
            {
                Id = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035"),
                SourceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "test_2"
            };
        }
    }
}