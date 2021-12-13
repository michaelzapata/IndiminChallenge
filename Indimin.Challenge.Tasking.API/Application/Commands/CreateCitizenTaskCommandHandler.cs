using AutoMapper;
using Indimin.Challenge.Tasking.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Commands
{
    public class CreateCitizenTaskCommandHandler : IRequestHandler<CreateCitizenTaskCommand, CreateCitizenTaskCommandResponse>
    {
        private readonly ICitizenTaskRepository _citizenTaskRepository;
        private readonly IMapper _mapper;

        public CreateCitizenTaskCommandHandler(ICitizenTaskRepository citizenTaskRepository, IMapper mapper)
        {
            _citizenTaskRepository = citizenTaskRepository ?? throw new ArgumentNullException(nameof(citizenTaskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateCitizenTaskCommandResponse> Handle(CreateCitizenTaskCommand request, CancellationToken cancellationToken)
        {
            var citizenTask = new CitizenTask(request.DayOfWeek, request.CitizenId, request.Description, request.IsActive);

            _citizenTaskRepository.Add(citizenTask);

            await _citizenTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return _mapper.Map<CreateCitizenTaskCommandResponse>(citizenTask);
        }
    }
}
