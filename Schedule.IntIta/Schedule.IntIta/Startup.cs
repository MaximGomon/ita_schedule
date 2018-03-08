using System;
using AspNet.Security.OAuth.Intita;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.Controllers;
using Schedule.IntIta.DataAccess;

namespace Schedule.IntIta
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.Filters.Add(new RequireHttpsAttribute());
                //options.Filters.Add(new ErrorFilter());
            });
            services.AddAutoMapper();

            //services.AddAuthentication(options =>
            //    {
            //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    })

            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/login";
            //        options.LogoutPath = "/signout";
            //    })
            //    .AddIntita(options =>
            //    {
            //        options.ClientId = "22";
            //        options.ClientSecret = "KCzNty3tuxoJ8z1kZ1MmPeGa1FaisPU2dCjkXkLK";
            //        options.SaveTokens = true;
            //    });

            services.AddSingleton<ISubjectRepository, SubjectRepository>();
            services.AddSingleton<ISubjectBusinessLogic, SubjectBusinessLogic>();
            services.AddSingleton<IEventBusinessLogic, EventBusinessLogic>();
            services.AddSingleton<IEventRepository, EventRepository>();
            services.AddSingleton<IEventTypeBusinessLogic, EventTypeBusinessLogic>();
            services.AddSingleton<IEventTypeRepository, EventTypeRepository>();

            //services
            //    .AddAuthentication
            //    (
            //        options =>
            //        {
            //            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //            //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //            options.DefaultAuthenticateScheme = IntitaAuthenticationDefaults.AuthenticationScheme;
            //            //options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        }
            //    )
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/singin";
            //        options.LogoutPath = "/signout";
            //    })
            //    .AddOAuth<IntitaAuthenticationOptions, IntitaAuthenticationHandler>(IntitaAuthenticationDefaults.AuthenticationScheme, options =>
            //    {
            //        options.ClientId = "22";
            //        options.ClientSecret = "KCzNty3tuxoJ8z1kZ1MmPeGa1FaisPU2dCjkXkLK";
            //        options.SaveTokens = true;
            //        // options.SignInScheme = IntitaAuthenticationDefaults.AuthenticationScheme;
            //    });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseExceptionHandler();
            app.UseMiddleware<ErrorWrappingMiddleware>();

            //app.UseAuthentication();

            //app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
                var r = routes.Routes;
            });
        }
    }

    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                return;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}