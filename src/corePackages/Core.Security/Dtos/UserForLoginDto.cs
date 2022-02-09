using Core.Security.Entities.Abstract;

namespace Core.Security.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
