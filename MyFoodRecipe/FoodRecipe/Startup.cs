using FoodRecipe.Data;
using FoodRecipe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipe
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connDb = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connDb);

            });
            //Register the OWIN Identity Middlware
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); /*FOR SENDING TOKENS*/

            //Register ASP.NET Razor Page Middleware
            services
                .AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            //Configure the Application Cookie options
            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(25);
                    options.SlidingExpiration = true; //for prevent to data loss
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Name = "FoodHubCookie";
                });

            //Register the EmailSender Service fo Dependency Injection
            services
                .AddSingleton<IEmailSender, MyEmailSenderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            RoleManager<IdentityRole> rolemanager, UserManager<IdentityUser> usermanager )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Activate the OWIN Middleware for Authentication
            app.UseAuthentication();/*ADDED BY MYSELF*/
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
               
                //Register  routes for in areas
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                //Register routes for not in areas
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            ApplicationDbContextSeed.SeedIdentityRolesAsync(rolemanager).Wait();
            ApplicationDbContextSeed.SeedIdentityUserAsync(usermanager).Wait();

        }
    }
}
