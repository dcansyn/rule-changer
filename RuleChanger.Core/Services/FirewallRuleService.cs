using NetFwTypeLib;
using RuleChanger.Core.Extensions;
using RuleChanger.Core.Models;
using RuleChanger.Core.Settings;
using System.Data;

namespace RuleChanger.Core.Services;

public interface IFirewallRuleService
{
    Task<RuleModel[]?> GetRules(string remoteAddress);
    Task<bool> Update(string remoteAddress, bool remoteDesktop, bool mySql, bool mssql, bool ftp);
}

public class FirewallRuleService(RuleSettings _settings) : IFirewallRuleService
{
    public async Task<RuleModel[]?> GetRules(string remoteAddress)
    {
        if (!OperatingSystem.IsWindows()) throw new Exception("Please just run on windows!");

        var policy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2")
            ?? throw new Exception("Policy2 not found!");

        if (Activator.CreateInstance(policy) is not INetFwPolicy2 firewallManager) throw new Exception("Firewall policy not found!");

        var inboundRules = firewallManager.Rules
            .Cast<INetFwRule>()
            .Where(x => x.RemoteAddresses.Contains(remoteAddress))
            .Select(x => new RuleModel
            {
                Name = x.Name,
                Grouping = x.Grouping,
                LocalPorts = x.LocalPorts,
                RemoteAddresses = x.RemoteAddresses
            })
            .OrderBy(x => x.Name)
            .ToArray();

        return await Task.FromResult(inboundRules);
    }

    public async Task<bool> Update(string remoteAddress, bool remoteDesktop, bool mySql, bool mssql, bool ftp)
    {
        if (!OperatingSystem.IsWindows()) throw new Exception("Please just run on windows!");

        var policy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2")
            ?? throw new Exception("Policy2 not found!");

        if (Activator.CreateInstance(policy) is not INetFwPolicy2 firewallManager) throw new Exception("Firewall policy not found!");

        foreach (INetFwRule item in firewallManager.Rules)
        {
            if (_settings.RemoteDesktop.Contains(item.Name))
                item.RemoteAddresses = item.RemoteAddresses.UpdateIpAddresses(remoteAddress, remoteDesktop);

            if (_settings.MySql.Contains(item.Name))
                item.RemoteAddresses = item.RemoteAddresses.UpdateIpAddresses(remoteAddress, mySql);

            if (_settings.MSSQL.Contains(item.Name))
                item.RemoteAddresses = item.RemoteAddresses.UpdateIpAddresses(remoteAddress, mssql);

            if (_settings.FTP.Contains(item.Name))
                item.RemoteAddresses = item.RemoteAddresses.UpdateIpAddresses(remoteAddress, ftp);
        }

        return await Task.FromResult(true);
    }
}
