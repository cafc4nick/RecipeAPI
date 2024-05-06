using Entities;

namespace Business.DTOs.Ingredient
{
    public class GetIngredientDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
