using MediatR;
using UserManagementApi.CQRS.Commands;
using UserManagementApi.Data;
using UserManagementApi.Models;
using Microsoft.EntityFrameworkCore;


namespace UserManagementApi.CQRS.Handlers
{
    // Kullan�c� olu�turma
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        // Dependency Injection ile DbContext al�n�r
        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Ayn� mailde kullan�c� var m� kontrol�
            var exists = await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);
            if (exists)
                throw new Exception("Bu email zaten kay�tl�."); // Daha sonra �zelle�tirebilirsin

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = request.Address
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

    }
}
