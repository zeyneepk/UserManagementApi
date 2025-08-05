using MediatR;

namespace UserManagementApi.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<Unit> 
    {
        [Required(ErrorMessage = "FirstName zorunludur.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "LastName zorunludur.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; } = string.Empty;

        public string? Address { get; set; }
    }
}
