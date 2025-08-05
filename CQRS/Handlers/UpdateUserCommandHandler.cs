using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.CQRS.Commands;
using UserManagementApi.Data;

namespace UserManagementApi.CQRS.Handlers
{
    // Kullan�c� g�ncelleme 
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // G�ncellenecek kullan�c�y� veritaban�ndan bul
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null) throw new Exception("User not found");

            // G�ncelle
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
