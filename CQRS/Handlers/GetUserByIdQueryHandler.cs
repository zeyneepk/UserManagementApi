using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.CQRS.Queries;
using UserManagementApi.Data;
using UserManagementApi.Models;

namespace UserManagementApi.CQRS.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
