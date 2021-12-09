using Microsoft.Extensions.Configuration;
using System;

namespace ErtsApiFetcher.Configurations {
    public class AppConfig {
        private readonly IConfiguration configuration;
        public bool IsRunningInDocker { get; }

        public AppConfig(IConfiguration configuration) {
            IsRunningInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
            this.configuration = configuration;
        }

        public string ErtsHangfireConnectionString =>
            IsRunningInDocker ? configuration.GetSection("Docker")[nameof(ErtsHangfireConnectionString)] :
            configuration.GetConnectionString(nameof(ErtsHangfireConnectionString));

        public string ErtsDbConnectionString =>
            IsRunningInDocker ? configuration.GetSection("Docker")[nameof(ErtsDbConnectionString)] :
            configuration.GetConnectionString(nameof(ErtsDbConnectionString));

        public string ErtsHangfireSchemaName => configuration.GetSection("Hangfire")[nameof(ErtsHangfireSchemaName)];

        public string PandaScoreApiToken => configuration.GetSection("PandaScore")[nameof(PandaScoreApiToken)];
    }
}
