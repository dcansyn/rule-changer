namespace RuleChanger.Core.Extensions;

public static class StringExtensions
{
    public static string UpdateIpAddresses(this string value, string ipAddress, bool isAdding)
    {
        if (string.IsNullOrEmpty(value)) return value;
        if (string.IsNullOrEmpty(ipAddress)) return value;

        var data = value.Split(',').ToList();

        if (!isAdding)
            data = data.Where(x => !x.Contains(ipAddress)).ToList();
        else if (!data.Contains(ipAddress))
            data.Add($"{ipAddress}/255.255.255.255");

        if (data.Count > 1 && data.Contains("*"))
            data = data.Where(x => !x.Contains('*')).ToList();

        return string.Join(",", data);
    }
}
