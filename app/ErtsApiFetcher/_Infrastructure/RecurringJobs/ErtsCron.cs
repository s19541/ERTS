namespace ErtsApiFetcher._Infrastructure.RecurringJobs {
    public class ErtsCron {
        public const string Minutely = "* * * * *";

        public const string Every5Minute = "*/5 * * * *";

        public const string OncePerWeek = "0 0 * * 0";
    }
}
