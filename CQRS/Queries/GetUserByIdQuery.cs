using MediatR;
using UserManagementApi.Models;

namespace UserManagementApi.CQRS.Queries
{
    public class GetUserByIdQuery : IRequest<User?>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
