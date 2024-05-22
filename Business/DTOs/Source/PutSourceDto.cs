using Business.DTOs.Interfaces;

namespace Business.DTOs.Source
{
    public class PutSourceDto : IPutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SourceTypeName { get; set; }

    }
}
