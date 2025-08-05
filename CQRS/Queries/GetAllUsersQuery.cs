using MediatR;
using UserManagementApi.Models;

namespace UserManagementApi.CQRS.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>> { }
}
