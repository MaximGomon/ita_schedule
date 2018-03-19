using System;
using AspNet.Security.OAuth.Intita;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Schedule.IntIta.BusinessLogic;
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
            
            services.AddAutoMapper();
            
            services.AddSingleton<ISubjectRepository, SubjectRepository>();
            services.AddSingleton<ISubjectBusinessLogic, SubjectBusinessLogic>();
            services.AddSingleton<IEventBusinessLogic, EventBusinessLogic>();
            services.AddSingleton<IEventRepository, EventRepository>();
            services.AddSingleton<IEventTypeBusinessLogic, EventTypeBusinessLogic>();
            services.AddSingleton<IEventTypeRepository, EventTypeRepository>();
            services.AddSingleton<IRoomBusinessLogic, RoomBusinessLogic>();
            services.AddSingleton<IRoomRepository, RoomRepository>();
            services.AddSingleton<IOfficeBusinessLogic, OfficeBusinessLogic>();
            services.AddSingleton<IOfficeRepository, OfficeRepository>();

            services.AddSingleton<ITimeSlotRepository, TimeSlotRepository>();
            services.AddSingleton<ITimeSlotTypesRepository, TimeSlotTypesRepository>();
            services.AddSingleton<ITimeSlotBuisnessLogic, TimeSlotBuisnessLogic>();
            services
                .AddAuthentication
                (
                    options =>
                    {
                        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultAuthenticateScheme = IntitaAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        
                    }
                )
                .AddCookie(options =>
                {
                    options.LoginPath = "/signin";
                    options.LogoutPath = "/signout";
                    options.Cookie.Name = "Intita.Oauth";
                })
                .AddOAuth<IntitaAuthenticationOptions, IntitaAuthenticationHandler>(IntitaAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = "22";
                    options.ClientSecret = "KCzNty3tuxoJ8z1kZ1MmPeGa1FaisPU2dCjkXkLK";
                    options.SaveTokens = true;
                    // options.SignInScheme = IntitaAuthenticationDefaults.AuthenticationScheme;
                });

           

            services.AddMvc(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
                //options.Filters.Add(new ErrorFilter());
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseExceptionHandler();
            app.UseMiddleware<ErrorWrappingMiddleware>();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authentication}/{action=SignIn}/{id?}");
            });
        }
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
