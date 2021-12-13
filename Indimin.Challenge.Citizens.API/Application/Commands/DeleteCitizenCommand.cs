using MediatR;

namespace Indimin.Challenge.Citizens.API.Application.Commands
{
    public class DeleteCitizenCommand : IRequest<bool>
    {
        public string Id { get; init; }
    }
}
