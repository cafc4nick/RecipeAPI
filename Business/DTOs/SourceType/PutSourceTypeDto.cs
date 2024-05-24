using Business.DTOs.Interfaces;

namespace Business.DTOs.SourceType
{
    public class PutSourceTypeDto : IPutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
