using MediatR;

namespace Indimin.Challenge.Tasking.API.Application.Commands
{
    public class DeleteCitizenTaskCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
