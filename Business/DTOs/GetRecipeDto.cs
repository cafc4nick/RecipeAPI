using Entities;

namespace Business.DTOs
{
    public class GetRecipeDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
