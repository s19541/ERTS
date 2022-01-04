using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.Enqueuers;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsModel;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ErtsApiFetcher {
    public class Startup {
        public Startup(IConfiguration configuration) {
            AppConfig = new AppConfig(configuration);
        }

        public AppConfig AppConfig { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ErtsContext>(options => options
               .UseLazyLoadingProxies()
               .UseNpgsql(AppConfig.ErtsDbConnectionString));

            InitializeDb(AppConfig.ErtsDbConnectionString);

            var hangfireJobStorage = GetJobStorage(AppConfig.ErtsHangfireConnectionString, AppConfig.ErtsHangfireSchemaName, true, 60, 120);
            var enqueuer = GetInstance(hangfireJobStorage);

            services.AddHangfire(configuration => configuration
                .UseStorage(hangfireJobStorage)
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings());

            services.AddHangfireServer(hangfireJobStorage);

            services.AddSingleton(enqueuer);
            services.AddSingleton<RecurringJobActivator>();
            services.AddSingleton(AppConfig);

            RecurringJobInitalizer.RegisterRecurringJobs(services);
            services.AddApiDataProcessors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RecurringJobInitalizer recurringJobInitalizer) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints => {
                endpoints.MapHangfireDashboard();
            });

            recurringJobInitalizer.ScheduleRecurringJobs();
        }

        public JobStorage GetJobStorage(string connectionString, string schemaName, bool prepareSchemaIfNecessary, int hangfireTransactionSynchronisationTimeoutInSeconds, int hangfireInvisibilityTimeoutInMinutes) {
            var jobStorage = new PostgreSqlStorage(connectionString,
                new PostgreSqlStorageOptions() {
                    SchemaName = schemaName,
                    PrepareSchemaIfNecessary = prepareSchemaIfNecessary,
                    EnableTransactionScopeEnlistment = true,
                    TransactionSynchronisationTimeout =
                        TimeSpan.FromSeconds(hangfireTransactionSynchronisationTimeoutInSeconds),
                    InvisibilityTimeout = TimeSpan.FromMinutes(hangfireInvisibilityTimeoutInMinutes)
                });

            return jobStorage;
        }

        public IEnqueuer GetInstance(JobStorage storage) {
            var backgroundJobClient = new BackgroundJobClient(storage);
            return new HangfireEnqueuer(backgroundJobClient, storage);
        }

        private void InitializeDb(string connectionString) {
            try {
                using (var context = new ErtsContext(connectionString)) {
                    context.Database.Migrate();
                    context.SaveChanges();
                }
            } catch (Exception ex) {
                Console.WriteLine($"Wyst¹pi³ b³¹d podczas aktualizacji bazy danych: {ex.Message}");
                throw;
            }
        }
    }
}
