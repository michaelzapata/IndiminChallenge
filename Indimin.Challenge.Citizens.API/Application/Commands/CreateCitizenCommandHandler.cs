using AutoMapper;
using Indimin.Challenge.Citizens.API.Application.Entities;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Commands
{
    public class CreateCitizenCommandHandler : IRequestHandler<CreateCitizenCommand, CreateCitizenCommandResponse>
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public CreateCitizenCommandHandler(ICitizenRepository citizenRepository, IMapper mapper)
        {
            _citizenRepository = citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateCitizenCommandResponse> Handle(CreateCitizenCommand request, CancellationToken cancellationToken)
        {
            var citizen = new Citizen
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IsActive = request.IsActive
            };
            
            await _citizenRepository.CreateCitizenAsync(citizen, cancellationToken);
            return _mapper.Map<CreateCitizenCommandResponse>(citizen);
        }
    }
}
