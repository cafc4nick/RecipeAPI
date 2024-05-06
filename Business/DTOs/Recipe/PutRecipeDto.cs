using Business.DTOs.Interfaces;

namespace Business.DTOs.Recipe
{
    public class PutRecipeDto : IPutDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
