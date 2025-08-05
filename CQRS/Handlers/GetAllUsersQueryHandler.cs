using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.CQRS.Queries;
using UserManagementApi.Data;
using UserManagementApi.Models;

namespace UserManagementApi.CQRS.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}
