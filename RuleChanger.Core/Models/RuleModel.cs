namespace RuleChanger.Core.Models;

public class RuleModel
{
    public string Name { get; set; } = default!;
    public string Grouping { get; set; } = default!;
    public string LocalPorts { get; set; } = default!;
    public string RemoteAddresses { get; set; } = default!;
}
