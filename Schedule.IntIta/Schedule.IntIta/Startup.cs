using System;
using System.Globalization;
using System.Net;
using AspNet.Security.OAuth.Intita;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Schedule.IntIta;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.Controllers;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Integration;


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
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<IUserIntegration, UserIntegration>();

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

        //if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
        //else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
        //else if (exception is MyException) code = HttpStatusCode.BadRequest;
        context.Response.StatusCode = (int)code;
        //var result = JsonConvert.SerializeObject(new { Message = "<h1> Exception message is: " + exception.Message +"</h1>"+ "<h2>Exception was caused by: " + exception.Source + "</h2>"});
        context.Response.ContentType = "text/HTML";
        var result = new ErrorPageMaker(exception, context).PageMaker();//так делать нельзя, но я сделал как мог
        
        return context.Response.WriteAsync(result);
    }
    
}
    
