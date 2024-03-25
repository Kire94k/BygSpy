using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

class Program
{
    static async Task Main(string[] args)
    {
        var users = new Dictionary<string, string>
        {
            { "user", "password1" },
            { "user2", "password2" }
        };

        var host = new WebHostBuilder()
            .UseKestrel()
            .Configure(app =>
            {
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapPost("/api/login", async context =>
                    {
                        var username = context.Request.Form["username"];
                        var password = context.Request.Form["password"];

                        if (users.TryGetValue(username, out string expectedPassword) && expectedPassword == password)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                    });
                });
            })
            .Build();

        await host.RunAsync();
    }
}
