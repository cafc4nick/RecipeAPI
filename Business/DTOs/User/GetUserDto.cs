using Entities;

namespace Business.DTOs.User
{
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }

    }
}
