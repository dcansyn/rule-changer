namespace RuleChanger.Core.Models;

public class FormSettingModel
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int TabIndex { get; set; }
    public List<FormSettingValueModel> Value { get; set; } = default!;
    public List<FormSettingModel> Children { get; set; } = default!;
}

public class FormSettingValueModel
{
    public int Index { get; set; }
    public object Data { get; set; } = default!;
    public bool Checked { get; set; }
    public bool Selected { get; set; }
    public List<FormSettingValueModel> Children { get; set; } = default!;
}