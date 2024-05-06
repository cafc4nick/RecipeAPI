using Business.DTOs.Interfaces;

namespace Business.DTOs.User
{
    public class PutUserDto : IPutDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }

    }
}
