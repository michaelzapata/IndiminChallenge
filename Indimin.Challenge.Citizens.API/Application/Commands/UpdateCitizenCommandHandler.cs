using AutoMapper;
using Indimin.Challenge.Citizens.API.Application.Entities;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Commands
{
    public class UpdateCitizenCommandHandler : IRequestHandler<UpdateCitizenCommand, bool>
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public UpdateCitizenCommandHandler(ICitizenRepository citizenRepository, IMapper mapper)
        {
            _citizenRepository = citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public Task<bool> Handle(UpdateCitizenCommand request, CancellationToken cancellationToken)
        {
            var citizen = _mapper.Map<Citizen>(request);
            return _citizenRepository.UpdateCitizenAsync(citizen, cancellationToken);
        }
    }
}
