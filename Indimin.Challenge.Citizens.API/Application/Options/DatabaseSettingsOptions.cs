namespace Indimin.Challenge.Citizens.API.Application.Options
{
    public class DatabaseSettingsOptions
    {
        public const string Section = "DatabaseSettings";
        public string ConnectionString { get; init; }
        public string DatabaseName { get; init; }
        public string CollectionName { get; init; }
    }
}
