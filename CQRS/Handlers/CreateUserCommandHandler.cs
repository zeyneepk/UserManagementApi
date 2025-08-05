using MediatR;
using UserManagementApi.CQRS.Commands;
using UserManagementApi.Data;
using UserManagementApi.Models;
using Microsoft.EntityFrameworkCore;


namespace UserManagementApi.CQRS.Handlers
{
    // Kullanýcý oluþturma
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        // Dependency Injection ile DbContext alýnýr
        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Ayný mailde kullanýcý var mý kontrolü
            var exists = await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);
            if (exists)
                throw new Exception("Bu email zaten kayýtlý."); // Daha sonra özelleþtirebilirsin

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
