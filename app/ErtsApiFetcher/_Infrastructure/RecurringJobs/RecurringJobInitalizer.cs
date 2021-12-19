using ErtsApiFetcher._Infrastructure.Enqueuers;
using ErtsApiFetcher.RecurringJobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ErtsApiFetcher._Infrastructure.RecurringJobs {
    public class RecurringJobInitalizer {
        private readonly IEnqueuer enqueuer;

        public RecurringJobInitalizer(IEnqueuer enqueuer) {
            this.enqueuer = enqueuer;
        }

        public void ScheduleRecurringJobs() {
            var recurringJobDtos = GetRecurringJobInfoAttributes().ToList();
            foreach (var recurringJobDto in recurringJobDtos) {
                enqueuer.AddRecurringJob(recurringJobDto);
            }
        }

        public static void RegisterRecurringJobs(IServiceCollection services) {
            services.AddSingleton<RecurringJobInitalizer>();

            services.AddScoped<LolInitialRecurringJob>();
            services.AddScoped<CsgoInitialRecurringJob>();
            services.AddScoped<ValorantInitialRecurringJob>();
            services.AddScoped<OwInitialRecurringJob>();
            services.AddScoped<Dota2InitialRecurringJob>();
            services.AddScoped<ShortRecurringJob>();
            services.AddScoped<DailyRecurringJob>();
            services.AddScoped<WeeklyRecurringJob>();
            services.AddScoped<LongRecurringJob>();
        }

        static IEnumerable<RecurringJobInfoAttribute> GetRecurringJobInfoAttributes() {
            foreach (Type type in typeof(RecurringJobInfoAttribute).Assembly.GetTypes()) {
                var dto = type.GetCustomAttribute<RecurringJobInfoAttribute>();
                if (dto != null) {
                    yield return dto;
                }
            }
        }
    }
}
