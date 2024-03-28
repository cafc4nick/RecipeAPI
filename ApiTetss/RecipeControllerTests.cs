using Business.DTOs.Recipe;
using Business.Interfaces;
using Moq;
using RecipeAPI.Controllers;

namespace ApiTetss
{
    [TestClass]
    public class RecipeControllerTests
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            var mockRepo = new Mock<IRecipeBusiness>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new RecipesController(mockRepo.Object);

            // Act
            var result = await controller.GetRecipes();

            // Assert
            Assert.AreEqual(result.Value.Count(), 2);
        }
        private List<GetRecipeDto> GetTestSessions()
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
    }
}