using Entities;

namespace Business.DTOs
{
    public class PostRecipeDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
