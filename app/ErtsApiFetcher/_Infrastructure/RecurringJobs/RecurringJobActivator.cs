using Microsoft.Extensions.DependencyInjection;
using System;

namespace ErtsApiFetcher._Infrastructure.RecurringJobs
{
    public class RecurringJobActivator
    {
        private readonly IServiceProvider serviceProvider;

        public RecurringJobActivator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void CreateScopeAndActivate(Type jobType)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                ((IRecurringJob)scope.ServiceProvider.GetService(jobType)).Job();
            }
        }
    }
}
