using MediatR;

namespace Indimin.Challenge.Tasking.API.Application.Commands
{
    public class UpdateCitizenTaskCommand : IRequest<bool>
    {
        public long Id { get; init; }
        public int DayOfWeek { get; init; }
        public string Description { get; init; }
        public bool IsActive { get; init; }
    }
}
