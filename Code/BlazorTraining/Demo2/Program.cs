using Demo2.Components;

namespace Demo2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            // For ConsumeAPI
            builder.Services.AddHttpClient();


            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            app.UseAntiforgery();

            app.MapStaticAssets();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
                //.AddInteractiveWebAssemblyRenderMode() //It will not support it because the project was not created solely for Blazor Server.
                //.AddInteractiveAutoRenderMode();       //It will not support it because the project was not created solely for Blazor Server.


            app.Run();
        }
    }
}
