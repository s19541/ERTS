using Microsoft.Extensions.Configuration;
using System;

namespace ErtsWebApp.Configuration {
    public class AppConfig {
        private readonly IConfiguration configuration;
        public bool IsRunningInDocker { get; }

        public AppConfig(IConfiguration configuration) {
            IsRunningInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
            this.configuration = configuration;
        }

        public string ErtsDbConnectionString =>
            IsRunningInDocker ? configuration.GetSection("Docker")[nameof(ErtsDbConnectionString)] :
            configuration.GetConnectionString(nameof(ErtsDbConnectionString));
    }
}
