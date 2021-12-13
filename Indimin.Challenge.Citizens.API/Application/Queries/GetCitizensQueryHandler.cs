using AutoMapper;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Queries
{
    public class GetCitizensQueryHandler : IRequestHandler<GetCitizensQuery, GetCitizensQueryResponse>
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public GetCitizensQueryHandler(ICitizenRepository citizenRepository, IMapper mapper)
        {
            _citizenRepository = citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCitizensQueryResponse> Handle(GetCitizensQuery request, CancellationToken cancellationToken)
        {
            var citizens = await _citizenRepository.GetCitizensAsync(cancellationToken);
            var citizenQueryResponseList = _mapper.Map<IEnumerable<GetCitizenQueryResponse>>(citizens);
            return new GetCitizensQueryResponse { Citizens = citizenQueryResponseList };
        }
    }
}
