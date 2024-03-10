using Entities.Base;

namespace Entities
{
    public class Recipe : EntityBase
    {
        public User User { get; set; }
        public Source Source { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Name {  get; set; }
    }
}