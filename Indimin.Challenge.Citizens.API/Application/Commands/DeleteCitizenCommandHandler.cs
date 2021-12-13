using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Commands
{
    public class DeleteCitizenCommandHandler : IRequestHandler<DeleteCitizenCommand, bool>
    {
        private readonly ICitizenRepository _citizenRepository;

        public DeleteCitizenCommandHandler(ICitizenRepository citizenRepository)
        {
            _citizenRepository = citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
        }

        public Task<bool> Handle(DeleteCitizenCommand request, CancellationToken cancellationToken)
        {
            return _citizenRepository.DeleteCitizenAsync(request.Id, cancellationToken);            
        }
    }
}
