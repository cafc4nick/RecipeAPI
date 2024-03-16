using Entities.Base;

namespace Entities
{
    public class Recipe : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Name {  get; set; }
    }
}