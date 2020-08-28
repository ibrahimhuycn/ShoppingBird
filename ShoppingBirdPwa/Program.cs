using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShoppingBirdPwa.Models;
using Grpc.Net.Client;
using Grpc.Core;

namespace ShoppingBirdPwa
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddScoped(sp =>   new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp =>
            {
                //var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
                return new Inventory.InventoryClient(GrpcChannel.ForAddress("https://localhost:5001"));
            });
            

            builder.Services.AddScoped<Cart>();
            await builder.Build().RunAsync();
        }
    }
}
