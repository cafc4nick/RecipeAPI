using Entities.Base;

namespace Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid UesrTypeId { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
