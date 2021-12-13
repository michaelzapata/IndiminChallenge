namespace Indimin.Challenge.BFF.Configurations
{
    public class ServicesOptions
    {
        public const string Section = "Services";
        public Client Citizens { get; init; }
        public Client CitizenTasks { get; init; }

    }

    public class Client
    {
        public string UrlBase { get; init; }
    }
}
