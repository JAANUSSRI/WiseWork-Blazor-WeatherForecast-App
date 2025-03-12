using BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp.Services;
using Supabase;
//using Supabase.Gotrue;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register WeatherService
builder.Services.AddScoped<GetWeatherService>();

// Register Supabase client with options
//builder.Services.AddScoped(provider =>
//    new Supabase.Client(
//        builder.Configuration["Supabase:Url"],
//        builder.Configuration["Supabase:Key"],
//        new Supabase.SupabaseOptions
//        {
//            AutoRefreshToken = true,
//            AutoConnectRealtime = true
//        }
//    )
//);

builder.Services.AddScoped(provider =>
    new Supabase.Client(
        "https://rfthifljiyemphuqyhmy.supabase.co",
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJmdGhpZmxqaXllbXBodXF5aG15Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDE2MDEzOTYsImV4cCI6MjA1NzE3NzM5Nn0.cyhcQKhSwsed3ZgIYHbenRr7QFWzMAEdi1q5Zrsa0Qg",
        new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }
    )
);

// Register AuthService
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();