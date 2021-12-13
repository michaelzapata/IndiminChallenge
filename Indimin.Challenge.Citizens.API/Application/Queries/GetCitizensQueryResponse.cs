using System.Collections.Generic;

namespace Indimin.Challenge.Citizens.API.Application.Queries
{
    public class GetCitizensQueryResponse
    {
        public IEnumerable<GetCitizenQueryResponse> Citizens { get; set; }
    }
}
