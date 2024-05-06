using Entities;

namespace Business.DTOs.Ingredient
{
    public class PostIngredientDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
