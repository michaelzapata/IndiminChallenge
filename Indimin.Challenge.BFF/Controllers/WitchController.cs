using Indimin.Challenge.BFF.Services;
using Indimin.Challenge.BFF.Services.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.BFF.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [EnableCors("CorsPolicy")]
    public class WitchController : ControllerBase
    {
        private readonly IBFFService _bFFService;

        public WitchController(IBFFService bFFService)
        {
            _bFFService = bFFService ?? throw new ArgumentNullException(nameof(bFFService));
        }

        [HttpGet("DayOfWeek/{dayOfWeek}")]
        [ProducesResponseType(typeof(CitizenTaskDataResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CitizenTaskDataResponse>> GetCitizenTaskByDayOfWeek([FromRoute] int dayOfWeek, CancellationToken cancellationToken = default)
        {
            var getCitizenQueryResponse = await _bFFService.GetCitizenTasksByDayOfWeek(dayOfWeek, cancellationToken);
            return Ok(getCitizenQueryResponse);
        }

        [HttpGet("DayOfWeek")]
        [ProducesResponseType(typeof(IEnumerable<DayOfWeekData>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<DayOfWeekData>>> GetDaysOfWeek(CancellationToken cancellationToken = default)
        {
            var getCitizenQueryResponse = await _bFFService.GetDaysOfWeek(cancellationToken);
            return Ok(getCitizenQueryResponse);
        }
    }
}
