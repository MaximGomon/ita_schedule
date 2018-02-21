using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })

                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/signout";
                })

                //.AddIntita(options =>
                //{
                //    options.ClientId = "22";
                //    options.ClientSecret = "KCzNty3tuxoJ8z1kZ1MmPeGa1FaisPU2dCjkXkLK";
                //})
                .AddOpenIdConnect(options =>
                {
                    options.ClientId = "22";
                    options.ClientSecret = "KCzNty3tuxoJ8z1kZ1MmPeGa1FaisPU2dCjkXkLK";
                })
                ;

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }

}