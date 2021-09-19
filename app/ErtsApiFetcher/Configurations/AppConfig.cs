using Microsoft.Extensions.Configuration;

namespace ErtsApiFetcher.Configurations
{
    public class AppConfig
    {
        private readonly IConfiguration configuration;

        public AppConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ErtsHangfireConnectionString => configuration.GetConnectionString(nameof(ErtsHangfireConnectionString));
        public string ErtsDbConnectionString => configuration.GetConnectionString(nameof(ErtsDbConnectionString));

        public string ErtsHangfireSchemaName => configuration.GetSection("Hangfire")[nameof(ErtsHangfireSchemaName)];
    }
}
