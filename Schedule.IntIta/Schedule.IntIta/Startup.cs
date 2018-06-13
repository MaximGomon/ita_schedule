using System;
using System.Dynamic;
using System.Globalization;
using System.Net;
using AspNet.Security.OAuth.Intita;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.Controllers;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Integration;
using Schedule.IntIta.Cache.Cache;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;

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

            services.AddTransient<ISubjectRepository, SubjectRepository>();

            services.AddSingleton<ICacheStore<Group>, CacheStore<Group>>();
            services.AddSingleton<IDataProvider<Group>, GroupDataProvider>();
            services.AddSingleton<ICacheManager<Group>, CacheManager<Group>>();

            services.AddTransient<ISubjectBusinessLogic, SubjectBusinessLogic>();
            services.AddTransient<IEventBusinessLogic, EventBusinessLogic>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventTypeBusinessLogic, EventTypeBusinessLogic>();
            services.AddTransient<IEventTypeRepository, EventTypeRepository>();
            services.AddTransient<IRoomBusinessLogic, RoomBusinessLogic>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IOfficeBusinessLogic, OfficeBusinessLogic>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ITimeSlotRepository, TimeSlotRepository>();
            services.AddTransient<ITimeSlotTypesRepository, TimeSlotTypesRepository>();
            services.AddTransient<ITimeSlotTypeBusinessLogic, TimeSlotTypesBusinessLogic>();
            services.AddTransient<ITimeSlotBuisnessLogic, TimeSlotBuisnessLogic>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ISubGroupRepository, SubGroupRepository>();
            services.AddTransient<IUserIntegration, UserIntegration>();
            services.AddTransient<IUserBusinessLogic, UserBusinessLogic>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IGroupIntegrationHandler, GroupIntegrationHandler>();
            services.AddDbContext<IntitaDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("IntitaDbContext")));

            services.AddDistributedMemoryCache();
            services.AddSession();
            services
                .AddAuthentication
                (
                    options =>
                    {
                        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
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
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<IntitaDbContext>().Database.Migrate();

                    var services = serviceScope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<IntitaDbContext>();
                        DbInitializer.Initialize(context);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}, Failed to migrate or seed database");
            }
            
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseSession();
            app.UseExceptionHandler();
            app.UseMiddleware<ErrorHandlingMiddleware>();
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

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
        try
        {
            await _next(context);
            if (context.Response.StatusCode == (int) HttpStatusCode.NotFound) throw new InvalidOperationException("404");
           
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected

        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "text/HTML";
        var result = new ErrorPageMaker(exception, context).PageMaker();//��� ������ ������, �� � ������ ��� ���
        
        return context.Response.WriteAsync(result);
    }
    
}
    
