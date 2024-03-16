using Entities.Base;

namespace Entities
{
    public class Source : EntityBase
    {
        public string Name { get; set; }
        public Guid SourceTypeId { get; set; }
    }

}