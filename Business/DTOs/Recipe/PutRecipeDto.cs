namespace Business.DTOs.Recipe
{
    public class PutRecipeDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
