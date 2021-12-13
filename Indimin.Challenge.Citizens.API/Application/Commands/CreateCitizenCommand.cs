using MediatR;

namespace Indimin.Challenge.Citizens.API.Application.Commands
{
    public class CreateCitizenCommand : IRequest<CreateCitizenCommandResponse>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public bool IsActive { get; init; }
    }
}
