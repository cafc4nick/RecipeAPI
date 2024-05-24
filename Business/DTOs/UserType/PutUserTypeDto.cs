using Business.DTOs.Interfaces;

namespace Business.DTOs.UserType
{
    public class PutUserTypeDto : IPutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
