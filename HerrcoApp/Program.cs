using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HerrcoApp
{
    public class Program
    {
        //private static readonly HttpClient client = new HttpClient();

        //static async Task Main(string[] args)
        //{
        //    Console.Write("Starting Task");
        //    await ProcessRepositories();
        //}

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //private static async Task ProcessRepositories()
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        //    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        //    var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

        //    var msg = await stringTask;
        //    Console.Write("Message ready");
        //    Console.Write(msg);
        //}
    }
}
