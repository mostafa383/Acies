using Microsoft.AspNetCore.Http;

namespace AciesManagmentProject.DTO
{
    public class AddUserDto
    {
        public string UserName { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public IFormFile UserImage { get; set; } = null;
    }
}
