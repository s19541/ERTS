using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsModel;
using Hangfire;
using System;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(DailyRecurringJob), nameof(DailyRecurringJob), ErtsCron.Daily)]
    public class DailyRecurringJob : TemporaryRecurringJobBase, IRecurringJob {
        public DailyRecurringJob(ErtsContext context) {
            this.context = context;
            from = DateTime.Now.AddDays(-1);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            updateAllGames();
        }

    }
}
