namespace Business.DTOs.Recipe
{
    public class PutIngredientDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}
