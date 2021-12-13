using AutoMapper;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Queries
{
    public class GetCitizenQueryHandler : IRequestHandler<GetCitizenQuery, GetCitizenQueryResponse>
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public GetCitizenQueryHandler(ICitizenRepository citizenRepository, IMapper mapper)
        {
            _citizenRepository = citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCitizenQueryResponse> Handle(GetCitizenQuery request, CancellationToken cancellationToken)
        {
            var citizen = await _citizenRepository.GetCitizenAsync(request.Id, cancellationToken);
            return _mapper.Map<GetCitizenQueryResponse>(citizen);
        }
    }
}
