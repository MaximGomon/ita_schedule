using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Schedule.IntIta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 44311);

                    using (var store = new X509Store(StoreName.Root))
                    {
                        store.Open(OpenFlags.ReadOnly);
                        var certs = store.Certificates.Find(X509FindType.FindBySerialNumber, "6390bcdcc7e76c98426254ab9608eb71", false);
                        if (certs.Count > 0)
                        {
                            var certificate = certs[0];

                            // listen for HTTPS
                            options.Listen(IPAddress.Any, 44310, listenOptions =>
                            {
                                listenOptions.UseHttps(certificate);
                            });
                        }
                    }

                })
                .UseStartup<Startup>()
                .Build();
    }
}
