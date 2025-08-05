using MediatR;
using UserManagementApi.CQRS.Commands;
using UserManagementApi.Data;

namespace UserManagementApi.CQRS.Handlers
{
    // Kullanýcý silme 
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // Silinecek kullanýcý bulunur
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null) throw new Exception("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
