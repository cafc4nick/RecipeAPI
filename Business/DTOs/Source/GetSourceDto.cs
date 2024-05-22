using Entities;

namespace Business.DTOs.Source
{
    public class GetSourceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SourceTypeId { get; set; }
        public string SourceTypeName { get; set; }

    }
}
