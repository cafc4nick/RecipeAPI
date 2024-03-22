using Entities;

namespace Business.DTOs.Recipe
{
    public class GetRecipeDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
