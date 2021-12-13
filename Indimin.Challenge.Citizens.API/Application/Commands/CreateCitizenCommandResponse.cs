namespace Indimin.Challenge.Citizens.API.Application.Commands
{
    public class CreateCitizenCommandResponse
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public bool IsActive { get; init; }
    }
}
