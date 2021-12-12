using System;

namespace ErtsApiFetcher._Infrastructure.RecurringJobs {
    public class RecurringJobInfoAttribute : Attribute {
        public RecurringJobInfoAttribute(Type jobType, string jobName, string cronTime) {
            JobType = jobType;
            JobName = jobName;
            CronTime = cronTime;
        }

        public Type JobType { get; }
        public string JobName { get; }
        public string CronTime { get; }
    }
}
