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
            var GivenRecipeWhenGetByIdThenGet = Guid.Parse("a30d1e75-ea74-40aa-bbd9-9f16a13e1035");
            var mockBusiness = new Mock<IRecipeBusiness>();
            mockBusiness.Setup(business => business.FindAsync(GivenRecipeWhenGetByIdThenGet))
                .ReturnsAsync(GetTestRecipe());
            var controller = new RecipesController(mockBusiness.Object);

            // Act
            var result = await controller.GetRecipe(GivenRecipeWhenGetByIdThenGet);

            // Assert
            Assert.AreEqual(result.Value.Name, "test_2");
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