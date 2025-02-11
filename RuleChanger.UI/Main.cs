using Microsoft.VisualBasic;
using RuleChanger.Core.Services;
using RuleChanger.Core.Settings;
using RuleChanger.UI.Events;
using RuleChanger.UI.Extensions;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;

namespace RuleChanger.UI;

public partial class Main : Form
{
    private readonly IFirewallRuleService _firewallRuleService;
    private readonly RuleSettings _settings;
    public Main(IFirewallRuleService firewallRuleService, RuleSettings settings)
    {
        _firewallRuleService = firewallRuleService;
        _settings = settings;

        InitializeComponent();
    }

    private bool isAvailableUpdate = false;

    private void Main_Load(object sender, EventArgs e)
    {
        TopMost = true;

        if (!this.ReadSettings())
            MessageBox.Show("Settings not found, please contact with programmer.");

        ChkRemoteDesktop.Checked = false;
        ChkMySql.Checked = false;
        ChkMSSQL.Checked = false;
        ChkFTP.Checked = false;
    }

    private void BtnAddUser_Click(object sender, EventArgs e)
    {
        var ipAddress = Interaction.InputBox($"Please enter the ip address.", "IP Address | Rule Changer");
        var detail = Interaction.InputBox($"Please enter detail for ip address.{Environment.NewLine}{Environment.NewLine}Example:Jhon Home IP", "IP Address | Rule Changer");

        if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(detail))
        {
            MessageBox.Show("Please enter all information for ip address.");
            return;
        }

        if (LVUsers.Items.Cast<ListViewItem>().Any(x => x.Text == ipAddress))
        {
            MessageBox.Show("This ip address already exists on list.");
            return;
        }

        LVUsers.Items.Add(new ListViewItem([ipAddress, detail]));
        this.SaveSettings();
    }

    private void LVUsers_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        LVUsers.MouseDoubleClickRemove();
        this.SaveSettings();
    }

    private async void LVUsers_Click(object sender, EventArgs e)
    {
        isAvailableUpdate = false;
        ChkRemoteDesktop.Checked = false;
        ChkMySql.Checked = false;
        ChkMSSQL.Checked = false;
        ChkFTP.Checked = false;

        if (LVUsers.FocusedItem == null) return;

        var rules = await _firewallRuleService.GetRules(LVUsers.FocusedItem.Text);
        if (rules == null) return;

        foreach (var item in rules)
        {
            if (_settings.RemoteDesktop.Contains(item.Name)) ChkRemoteDesktop.Checked = true;
            if (_settings.MySql.Contains(item.Name)) ChkMySql.Checked = true;
            if (_settings.MSSQL.Contains(item.Name)) ChkMSSQL.Checked = true;
            if (_settings.FTP.Contains(item.Name)) ChkFTP.Checked = true;
        }

        isAvailableUpdate = true;
    }

    private async void ChkRemoteDesktop_CheckedChanged(object sender, EventArgs e) { await UpdateUser(); }
    private async void ChkMySql_CheckedChanged(object sender, EventArgs e) { await UpdateUser(); }
    private async void ChkMSSQL_CheckedChanged(object sender, EventArgs e) { await UpdateUser(); }
    private async void ChkFTP_CheckedChanged(object sender, EventArgs e) { await UpdateUser(); }

    private async Task UpdateUser()
    {
        if (LVUsers.FocusedItem == null || !isAvailableUpdate) return;

        var result = await _firewallRuleService.Update(LVUsers.FocusedItem.Text, ChkRemoteDesktop.Checked, ChkMySql.Checked, ChkMSSQL.Checked, ChkFTP.Checked);
        if (!result) MessageBox.Show("Rules not changed, please contact with programmer.");
    }
}
