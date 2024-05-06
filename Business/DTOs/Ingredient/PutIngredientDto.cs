using Business.DTOs.Interfaces;

namespace Business.DTOs.Ingredient
{
    public class PutIngredientDto : IPutDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
