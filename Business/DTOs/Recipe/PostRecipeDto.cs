using Entities;

namespace Business.DTOs.Recipe
{
    public class PostRecipeDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
