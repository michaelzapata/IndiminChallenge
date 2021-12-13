using AutoMapper;
using Indimin.Challenge.Tasking.Domain.Models;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTasksQueryHandler : IRequestHandler<GetCitizenTasksQuery, GetCitizenTasksQueryResponse>
    {
        private readonly ICitizenTaskRepository _citizenTaskRepository;
        private readonly IMapper _mapper;

        public GetCitizenTasksQueryHandler(ICitizenTaskRepository citizenTaskRepository, IMapper mapper)
        {
            _citizenTaskRepository = citizenTaskRepository ?? throw new ArgumentNullException(nameof(citizenTaskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCitizenTasksQueryResponse> Handle(GetCitizenTasksQuery request, CancellationToken cancellationToken)
        {
            var citizenTasks = await _citizenTaskRepository.GetsAsync();

            var citizenTaskResponseList = _mapper.Map<IEnumerable<GetCitizenTaskQueryResponse>>(citizenTasks);

            return new GetCitizenTasksQueryResponse { CitizenTasks = citizenTaskResponseList };
        }
    }
}
