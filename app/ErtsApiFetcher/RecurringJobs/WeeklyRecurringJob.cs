using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsModel;
using Hangfire;
using System;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(WeeklyRecurringJob), nameof(WeeklyRecurringJob), ErtsCron.Weekly)]
    public class WeeklyRecurringJob : TemporaryRecurringJobBase, IRecurringJob {
        public WeeklyRecurringJob(ErtsContext context) {
            this.context = context;
            from = DateTime.Now.AddDays(-7);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            updateAllGames();
        }

    }
}
