namespace ErtsApiFetcher._Infrastructure.RecurringJobs
{
    public interface IRecurringJob
    {
        string JobName { get; }
        string CronTime { get; }
        void Job();
    }
}
