using DNTScheduler.Core;
using DNTScheduler.Core.Contracts;
using Framework.Core.DependencyInjection;
using Framework.DependencyInjection;
using Framework.DIAssemblyLoader;
using IeltsProject.Presentation.Data;
using IeltsProject.Presentation.EmailServer;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace IeltsProject.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyLoader = new AssemblyLoader("ExamContext.");
            Registrar(services, assemblyLoader);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();


            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                   .AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(240);
                options.SlidingExpiration = true;
            });


            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(240); });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddTransient<IMyEmailSender, MyEmailSender>();

            services.AddDNTScheduler(options =>
            {
                // DNTScheduler needs a ping service to keep it alive.
                // If you don't need it, don't add it!
                options.AddPingTask(siteRootUrl: "https://userpanel.bpvielts.com/");
            });

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());

        }

        private void Registrar(IServiceCollection services, AssemblyLoader assemblyLoader)
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("AppSettings.json", true, true)
               .AddJsonFile($"AppSettings.appsettings.json", true, true);
            var connectionString = builder.Build().GetConnectionString("DefaultConnection");
            var registrars = assemblyLoader.GetInstanceByInterface(typeof(IRegistrar));
            foreach (IRegistrar registrar in registrars)
            {
                registrar.Register(services, connectionString);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDNTScheduler();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
