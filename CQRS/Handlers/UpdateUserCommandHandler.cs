using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.CQRS.Commands;
using UserManagementApi.Data;

namespace UserManagementApi.CQRS.Handlers
{
    // Kullanýcý güncelleme 
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Güncellenecek kullanýcýyý veritabanýndan bul
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null) throw new Exception("User not found");

            // Güncelle
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
