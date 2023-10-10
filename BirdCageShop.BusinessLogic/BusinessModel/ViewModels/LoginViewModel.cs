namespace Ecommerce.BusinessLogic.ViewModels
{
    public class LoginViewModel
    {
        public string UserId { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }
    }
}
