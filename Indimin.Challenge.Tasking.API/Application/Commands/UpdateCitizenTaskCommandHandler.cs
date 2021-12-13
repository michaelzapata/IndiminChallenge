using Indimin.Challenge.Tasking.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Commands
{
    public class UpdateCitizenTaskCommandHandler : IRequestHandler<UpdateCitizenTaskCommand, bool>
    {
        private readonly ICitizenTaskRepository _citizenTaskRepository;

        public UpdateCitizenTaskCommandHandler(ICitizenTaskRepository citizenTaskRepository)
        {
            _citizenTaskRepository = citizenTaskRepository ?? throw new ArgumentNullException(nameof(citizenTaskRepository));
        }
        public async Task<bool> Handle(UpdateCitizenTaskCommand request, CancellationToken cancellationToken)
        {
            var citizenTask = await _citizenTaskRepository.GetAsync(request.Id);
            if(citizenTask is not null)
            {
                citizenTask.ChangeDayOfWeek(request.DayOfWeek);
                citizenTask.ChangeDescription(request.Description);
                citizenTask.ChangeState(request.IsActive);

                _citizenTaskRepository.Update(citizenTask);

                return await _citizenTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
            return false;
        }
    }
}
