using Entities.Base;

namespace Entities
{
    public class UserType : EntityBase
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}