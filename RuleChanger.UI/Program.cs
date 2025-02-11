using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RuleChanger.Core.Services;
using RuleChanger.Core.Settings;

namespace RuleChanger.UI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", true, true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<Main>();
                services.AddSingleton(context.Configuration.GetSection("Rules").Get<RuleSettings>() ?? new RuleSettings());
                services.AddTransient<IFirewallRuleService, FirewallRuleService>();
            }).Build();

        Application.Run(host.Services.GetRequiredService<Main>());
    }
}