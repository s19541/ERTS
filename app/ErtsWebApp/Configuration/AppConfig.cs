using Microsoft.Extensions.Configuration;

namespace ErtsWebApp.Configuration
{
    public class AppConfig
    {
        private readonly IConfiguration configuration;

        public AppConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ErtsDbConnectionString => configuration.GetConnectionString("ErtsDbConnectionString");
    }
}
