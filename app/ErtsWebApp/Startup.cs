using ErtsApplication.DAL;
using ErtsModel;
using ErtsWebApp.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace ErtsWebApp {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            var appConfig = new AppConfig(Configuration);
            services.AddSingleton(appConfig);

            services.AddDbContext<ErtsContext>(
                options => options
                .UseLazyLoadingProxies()
                .UseNpgsql(appConfig.ErtsDbConnectionString));

            BindServices(services);

            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/build";
            });

            InitializeDb(appConfig.ErtsDbConnectionString);

            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private void InitializeDb(string connectionString) {
            try {
                using (var context = new ErtsContext(connectionString)) {
                    if (context.Database.GetPendingMigrations()?.Any() == true) {
                        context.Database.Migrate();
                        context.SaveChanges();
                    }
                    //   }
                    //  else
                    // {
                    //    new ErtsFakeSeeder().SeedFakeData(context);
                    // }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Wyst¹pi³ b³¹d podczas aktualizacji bazy danych: {ex.Message}");
                throw;
            }
        }

        private void BindServices(IServiceCollection services) {
            services.AddScoped<ILeagueDbService, LeagueDbService>();
            services.AddScoped<ITournamentDbService, TournamentDbService>();
            services.AddScoped<ISerieDbService, SerieDbService>();
            services.AddScoped<IMatchDbService, MatchDbService>();
            services.AddScoped<IGameDbService, GameDbService>();
            services.AddScoped<ITeamDbService, TeamDbService>();
        }
    }
}
