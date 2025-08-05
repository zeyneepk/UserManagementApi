using MediatR;

namespace UserManagementApi.CQRS.Commands
{
    public class DeleteUserCommand : IRequest<Unit> 
    {
        public int Id { get; set; }
    }
}
