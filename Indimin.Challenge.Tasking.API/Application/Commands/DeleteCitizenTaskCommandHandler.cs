using Indimin.Challenge.Tasking.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Commands
{
    public class DeleteCitizenTaskCommandHandler : IRequestHandler<DeleteCitizenTaskCommand, bool>
    {
        private readonly ICitizenTaskRepository _citizenTaskRepository;

        public DeleteCitizenTaskCommandHandler(ICitizenTaskRepository citizenTaskRepository)
        {
            _citizenTaskRepository = citizenTaskRepository ?? throw new ArgumentNullException(nameof(citizenTaskRepository));
        }

        public async Task<bool> Handle(DeleteCitizenTaskCommand request, CancellationToken cancellationToken)
        {
            await _citizenTaskRepository.Delete(request.Id);

            return await _citizenTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
