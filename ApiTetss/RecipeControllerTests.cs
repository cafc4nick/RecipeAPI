using Business.DTOs.Recipe;
using Business.Exceptions;
using Business.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeAPI.Controllers;

namespace ApiTetss
{
    [TestClass]
    public class RecipeControllerTests
    {
        [TestMethod]
        public async Task GivenRecipesWhenGetThenReturn()
        {
            // Arrange
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(business => business.GetAllAsync())
                .ReturnsAsync(GetTestRecipes());
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.GetRecipes();

            // Assert
            Assert.AreEqual(result.Value.Count(), 2);
        }
        [TestMethod]
        public async Task GivenRecipeWhenGetByIdThenGet()
        {
            // Arrange
            var recipeId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(business => business.FindAsync(recipeId))
                .ReturnsAsync(GetTestRecipe());
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.GetRecipe(recipeId);

            // Assert
            Assert.AreEqual(result.Value.Name, "test_2");
        }
        [TestMethod]
        public async Task GivenNoRecipeWhenGetByIdThenThrow()
        {
            // Arrange
            var recipeId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(business => business.FindAsync(recipeId))
                .Returns(Task.FromResult<GetRecipeDto>(null));
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.GetRecipe(recipeId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenNoRecipeWhenDeleteThenThrow()
        {
            // Arrange
            var recipeId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(recipeId))
                .Throws(new NotFoundException());
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.GetRecipe(recipeId);

            // Assert
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
        [TestMethod]
        public async Task GivenRecipeWhenDeleteThenDelete()
        {
            // Arrange
            var recipeId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1031");
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(business => business.DeleteAsync(recipeId))
                .Returns(Task.FromResult<GetRecipeDto>(null));
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.DeleteRecipe(recipeId);

            // Assert
            mockBusiness.Verify(b => b.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenValidRecipeWhenPutThenUpdate()
        {
            // Arrange
            var recipeId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var recipePutDto = new PutRecipeDto()
            {
                UserId = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                Id = recipeId,
                Name = "test"
            };
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(x => x.PutAsync(recipeId, recipePutDto)).Verifiable();
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.PutRecipe(recipeId, recipePutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutRecipeDto>()), Times.Once);
        }
        [TestMethod]
        public async Task GivenInValidRecipeWhenPutThenThrow()
        {
            // Arrange
            var recipeId = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var recipePutDto = new PutRecipeDto()
            {
                UserId = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Name = "test"
            };
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(x => x.PutAsync(recipeId, recipePutDto)).Verifiable();
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.PutRecipe(recipeId, recipePutDto);

            // Assert
            mockBusiness.Verify(b => b.PutAsync(It.IsAny<Guid>(), It.IsAny<PutRecipeDto>()), Times.Never);
            Assert.IsInstanceOfType<BadRequestResult>(result);
        }
        private List<GetRecipeDto> GetTestRecipes()
        {
            var recipes = new List<GetRecipeDto>();
            recipes.Add(new GetRecipeDto()
            {
                Id = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "test_1"
            });
            recipes.Add(new GetRecipeDto()
            {
                Id = Guid.NewGuid(),
                SourceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "test_2"
            });
            return recipes;
        }

        private GetRecipeDto GetTestRecipe()
        {
            return new GetRecipeDto()
            {
                Id = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035"),
                SourceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "test_2"
            };
        }
    }
}