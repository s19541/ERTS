using ErtsApiFetcher._Infrastructure.Enqueuers;
using ErtsApiFetcher.RecurringJobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ErtsApiFetcher._Infrastructure.RecurringJobs
{
    public class RecurringJobInitalizer
    {
        private readonly IEnqueuer enqueuer;
        private IRecurringJob[] recurringJobs;

        public RecurringJobInitalizer(IEnqueuer enqueuer, IServiceProvider serviceProvider)
        {
            this.enqueuer = enqueuer;
            this.recurringJobs = serviceProvider.GetServices<IRecurringJob>().ToArray();
        }

        public void ScheduleRecurringJobs()
        {
            foreach (var recurringJob in recurringJobs)
            {
                enqueuer.AddRecurringJob(recurringJob);
            }
        }

        public static void RegisterRecurringJobs(IServiceCollection services)
        {
            services.AddSingleton<RecurringJobInitalizer>();

            services.AddTransient<IRecurringJob, TestRecurringJob>();
            services.AddTransient<IRecurringJob, SecondRecurringJob>();
        }
    }
}
