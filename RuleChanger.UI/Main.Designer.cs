namespace RuleChanger.UI;

partial class Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        LVUsers = new ListView();
        ClmnUserIpAddress = new ColumnHeader();
        ClmnUserDetail = new ColumnHeader();
        GbUsers = new GroupBox();
        BtnAddUser = new Button();
        GbRules = new GroupBox();
        ChkFTP = new CheckBox();
        ChkMSSQL = new CheckBox();
        ChkMySql = new CheckBox();
        ChkRemoteDesktop = new CheckBox();
        GbUsers.SuspendLayout();
        GbRules.SuspendLayout();
        SuspendLayout();
        // 
        // LVUsers
        // 
        LVUsers.Columns.AddRange(new ColumnHeader[] { ClmnUserIpAddress, ClmnUserDetail });
        LVUsers.FullRowSelect = true;
        LVUsers.GridLines = true;
        LVUsers.HideSelection = true;
        LVUsers.Location = new Point(6, 22);
        LVUsers.MultiSelect = false;
        LVUsers.Name = "LVUsers";
        LVUsers.Size = new Size(389, 164);
        LVUsers.TabIndex = 0;
        LVUsers.UseCompatibleStateImageBehavior = false;
        LVUsers.View = View.Details;
        LVUsers.Click += LVUsers_Click;
        LVUsers.MouseDoubleClick += LVUsers_MouseDoubleClick;
        // 
        // ClmnUserIpAddress
        // 
        ClmnUserIpAddress.Text = "Ip Address";
        ClmnUserIpAddress.Width = 150;
        // 
        // ClmnUserDetail
        // 
        ClmnUserDetail.Text = "Detail";
        ClmnUserDetail.Width = 200;
        // 
        // GbUsers
        // 
        GbUsers.Controls.Add(BtnAddUser);
        GbUsers.Controls.Add(LVUsers);
        GbUsers.Location = new Point(12, 12);
        GbUsers.Name = "GbUsers";
        GbUsers.Size = new Size(401, 232);
        GbUsers.TabIndex = 1;
        GbUsers.TabStop = false;
        GbUsers.Text = "Users";
        // 
        // BtnAddUser
        // 
        BtnAddUser.Location = new Point(6, 192);
        BtnAddUser.Name = "BtnAddUser";
        BtnAddUser.Size = new Size(389, 34);
        BtnAddUser.TabIndex = 1;
        BtnAddUser.Text = "Add New User";
        BtnAddUser.UseVisualStyleBackColor = true;
        BtnAddUser.Click += BtnAddUser_Click;
        // 
        // GbRules
        // 
        GbRules.Controls.Add(ChkFTP);
        GbRules.Controls.Add(ChkMSSQL);
        GbRules.Controls.Add(ChkMySql);
        GbRules.Controls.Add(ChkRemoteDesktop);
        GbRules.Location = new Point(419, 12);
        GbRules.Name = "GbRules";
        GbRules.Size = new Size(210, 232);
        GbRules.TabIndex = 2;
        GbRules.TabStop = false;
        GbRules.Text = "Rules";
        // 
        // ChkFTP
        // 
        ChkFTP.AutoSize = true;
        ChkFTP.Location = new Point(31, 190);
        ChkFTP.Name = "ChkFTP";
        ChkFTP.Size = new Size(46, 19);
        ChkFTP.TabIndex = 3;
        ChkFTP.Text = "FTP";
        ChkFTP.UseVisualStyleBackColor = true;
        ChkFTP.CheckedChanged += ChkFTP_CheckedChanged;
        // 
        // ChkMSSQL
        // 
        ChkMSSQL.AutoSize = true;
        ChkMSSQL.Location = new Point(31, 138);
        ChkMSSQL.Name = "ChkMSSQL";
        ChkMSSQL.Size = new Size(67, 19);
        ChkMSSQL.TabIndex = 2;
        ChkMSSQL.Text = "MS SQL";
        ChkMSSQL.UseVisualStyleBackColor = true;
        ChkMSSQL.CheckedChanged += ChkMSSQL_CheckedChanged;
        // 
        // ChkMySql
        // 
        ChkMySql.AutoSize = true;
        ChkMySql.Location = new Point(31, 86);
        ChkMySql.Name = "ChkMySql";
        ChkMySql.Size = new Size(62, 19);
        ChkMySql.TabIndex = 1;
        ChkMySql.Text = "My Sql";
        ChkMySql.UseVisualStyleBackColor = true;
        ChkMySql.CheckedChanged += ChkMySql_CheckedChanged;
        // 
        // ChkRemoteDesktop
        // 
        ChkRemoteDesktop.AutoSize = true;
        ChkRemoteDesktop.Location = new Point(31, 34);
        ChkRemoteDesktop.Name = "ChkRemoteDesktop";
        ChkRemoteDesktop.Size = new Size(113, 19);
        ChkRemoteDesktop.TabIndex = 0;
        ChkRemoteDesktop.Text = "Remote Desktop";
        ChkRemoteDesktop.UseVisualStyleBackColor = true;
        ChkRemoteDesktop.CheckedChanged += ChkRemoteDesktop_CheckedChanged;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(641, 256);
        Controls.Add(GbRules);
        Controls.Add(GbUsers);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "Main";
        Text = "Rule Changer";
        Load += Main_Load;
        GbUsers.ResumeLayout(false);
        GbRules.ResumeLayout(false);
        GbRules.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ListView LVUsers;
    private ColumnHeader ClmnUserDetail;
    private ColumnHeader ClmnUserIpAddress;
    private GroupBox GbUsers;
    private Button BtnAddUser;
    private GroupBox GbRules;
    private CheckBox ChkRemoteDesktop;
    private CheckBox ChkFTP;
    private CheckBox ChkMSSQL;
    private CheckBox ChkMySql;
}
