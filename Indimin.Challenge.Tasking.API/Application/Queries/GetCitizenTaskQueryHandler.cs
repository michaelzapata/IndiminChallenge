using AutoMapper;
using Indimin.Challenge.Tasking.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTaskQueryHandler : IRequestHandler<GetCitizenTaskQuery, GetCitizenTaskQueryResponse>
    {
        private readonly ICitizenTaskRepository _citizenTaskRepository;
        private readonly IMapper _mapper;

        public GetCitizenTaskQueryHandler(ICitizenTaskRepository citizenTaskRepository, IMapper mapper)
        {
            _citizenTaskRepository = citizenTaskRepository ?? throw new ArgumentNullException(nameof(citizenTaskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCitizenTaskQueryResponse> Handle(GetCitizenTaskQuery request, CancellationToken cancellationToken)
        {
            var citizenTask = await _citizenTaskRepository.GetAsync(request.Id);

            return _mapper.Map<GetCitizenTaskQueryResponse>(citizenTask);
        }
    }
}
