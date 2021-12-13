namespace Indimin.Challenge.Tasking.API.Application.Configurations
{
    public class DatabaseSettingsOptions
    {
        public const string Section = "DatabaseSettings";
        public string ConnectionString { get; init; }
    }
}
