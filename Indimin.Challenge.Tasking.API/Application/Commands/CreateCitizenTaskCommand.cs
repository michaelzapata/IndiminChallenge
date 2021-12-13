using MediatR;
using System.Collections.Generic;

namespace Indimin.Challenge.Tasking.API.Application.Commands
{
    public class CreateCitizenTaskCommand : IRequest<CreateCitizenTaskCommandResponse>
    {
        public string CitizenId { get; init; }
        public int DayOfWeek { get; init; }
        public string Description { get; init; }
        public bool IsActive { get; init; }
    }
}
