using Indimin.Challenge.Citizens.API.Application.Commands;
using Indimin.Challenge.Citizens.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitizensController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetCitizensQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCitizensQueryResponse>> GetCitizens(CancellationToken cancellationToken = default)
        {
            var getCitizensQueryResponse = await _mediator.Send(new GetCitizensQuery(), cancellationToken);
            if (getCitizensQueryResponse.Citizens.Any())
                return Ok(getCitizensQueryResponse);
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCitizenQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCitizenQueryResponse>> GetCitizen([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var getCitizenQueryResponse = await _mediator.Send(new GetCitizenQuery { Id = id }, cancellationToken);
            if (getCitizenQueryResponse is not null)
                return Ok(getCitizenQueryResponse);
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateCitizen([FromBody] CreateCitizenCommand createCitizenCommand, CancellationToken cancellationToken = default)
        {
            var createCitizenCommandResponse = await _mediator.Send(createCitizenCommand, cancellationToken);
            return CreatedAtAction(nameof(GetCitizen), new { id = createCitizenCommandResponse.Id }, createCitizenCommand);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateCitizen([FromBody] UpdateCitizenCommand updateCitizenCommand, CancellationToken cancellationToken = default)
        {
            var isUpdated = await _mediator.Send(updateCitizenCommand, cancellationToken);
            if (isUpdated)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteCitizen([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var isDeleted = await _mediator.Send(new DeleteCitizenCommand { Id = id }, cancellationToken);
            if (isDeleted)
                return Ok();
            return BadRequest();
        }
    }
}
