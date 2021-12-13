using Indimin.Challenge.Tasking.API.Application.Commands;
using Indimin.Challenge.Tasking.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CitizenTasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitizenTasksController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCitizenTaskQueryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCitizenTaskQueryResponse>> GetCitizenTasks(CancellationToken cancellationToken = default)
        {
            var getCitizensQueryResponse = await _mediator.Send(new GetCitizenTasksQuery(), cancellationToken);
            if (getCitizensQueryResponse.CitizenTasks.Any())
                return Ok(getCitizensQueryResponse);
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCitizenTaskQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCitizenTaskQueryResponse>> GetCitizenTask([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var getCitizenQueryResponse = await _mediator.Send(new GetCitizenTaskQuery { Id = id }, cancellationToken);
            if (getCitizenQueryResponse is not null)
                return Ok(getCitizenQueryResponse);
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateCitizenTask([FromBody] CreateCitizenTaskCommand createCitizenTaskCommand, CancellationToken cancellationToken = default)
        {
            var createCitizenTaskCommandResponse = await _mediator.Send(createCitizenTaskCommand, cancellationToken);
            return CreatedAtAction(nameof(GetCitizenTask), new { id = createCitizenTaskCommandResponse.Id }, createCitizenTaskCommand);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateCitizenTask([FromBody] UpdateCitizenTaskCommand updateCitizenTaskCommand, CancellationToken cancellationToken = default)
        {
            var isUpdated = await _mediator.Send(updateCitizenTaskCommand, cancellationToken);
            if (isUpdated)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteCitizen([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var isDeleted = await _mediator.Send(new DeleteCitizenTaskCommand { Id = id }, cancellationToken);
            if (isDeleted)
                return Ok();
            return BadRequest();
        }

        [HttpGet("Citizen/{citizenId}")]
        [ProducesResponseType(typeof(GetCitizenTasksQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCitizenTasksQueryResponse>> GetCitizenTaskByCitizenId([FromRoute] string citizenId, CancellationToken cancellationToken = default)
        {
            var getCitizenQueryResponse = await _mediator.Send(new GetCitizenTasksByCitizenIdQuery { CitizenId = citizenId }, cancellationToken);
            if (getCitizenQueryResponse is not null && getCitizenQueryResponse.CitizenTasks.Any())
                return Ok(getCitizenQueryResponse);
            return NotFound();
        }

        [HttpGet("DayOfWeek/{dayOfWeek}")]
        [ProducesResponseType(typeof(GetCitizenTasksQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCitizenTasksQueryResponse>> GetCitizenTaskByDayOfWeek([FromRoute] int dayOfWeek, CancellationToken cancellationToken = default)
        {
            var getCitizenQueryResponse = await _mediator.Send(new GetCitizenTasksByDayOfWeekQuery { DayOfWeek = dayOfWeek }, cancellationToken);
            if (getCitizenQueryResponse is not null && getCitizenQueryResponse.CitizenTasks.Any())
                return Ok(getCitizenQueryResponse);
            return NotFound();
        }

        [HttpGet("DayOfWeek")]
        [ProducesResponseType(typeof(GetDaysOfWeekQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetDaysOfWeekQueryResponse>> GetDaysOfWeek(CancellationToken cancellationToken = default)
        {
            var getDaysOfWeekQueryResponse = await _mediator.Send(new GetDaysOfWeekQuery(), cancellationToken);
            if (getDaysOfWeekQueryResponse is not null && getDaysOfWeekQueryResponse.DaysOfWeek.Any())
                return Ok(getDaysOfWeekQueryResponse);
            return NotFound();
        }

    }
}
