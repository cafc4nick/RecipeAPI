using Entities.Base;

namespace Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public UserType UesrType { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
