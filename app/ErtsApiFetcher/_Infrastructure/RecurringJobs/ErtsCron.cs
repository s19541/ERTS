namespace ErtsApiFetcher._Infrastructure.RecurringJobs {
    public class ErtsCron {
        public const string Minutely = "* * * * *";

        public const string Every5Minutes = "*/5 * * * *";

        public const string Weekly = "0 0 * * 0";

        public const string Never = "0 0 5 31 2 ?";

        public const string Daily = "0 8 * * *";

        public const string Hourly = "5 * * * *";

        public const string Every10Minutes = "30 */10 * * * *";

    }
}
