namespace LinuxMySQLBackupTool
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        // Declare controls here:
        private System.Windows.Forms.ComboBox cmbIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblSSHUser;
        private System.Windows.Forms.TextBox txtSSHUser;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox groupBoxAuth;
        private System.Windows.Forms.RadioButton rdoRSA;
        private System.Windows.Forms.RadioButton rdoPassword;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.TextBox txtPrivateKeyPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFingerprint;
        private System.Windows.Forms.TextBox txtFingerprint;
        private System.Windows.Forms.Label lblSSHPwd;
        private System.Windows.Forms.TextBox txtSSHPwd;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label lblMySQLUser;
        private System.Windows.Forms.TextBox txtMySQLUser;
        private System.Windows.Forms.Label lblMySQLPassword;
        private System.Windows.Forms.TextBox txtMySQLPassword;
        private System.Windows.Forms.Label lblBackupFolder;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnBackup;

        // The RichTextBox for logs
        private System.Windows.Forms.RichTextBox rtbLog;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbIP = new System.Windows.Forms.ComboBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblSSHUser = new System.Windows.Forms.Label();
            this.txtSSHUser = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBoxAuth = new System.Windows.Forms.GroupBox();
            this.rdoRSA = new System.Windows.Forms.RadioButton();
            this.rdoPassword = new System.Windows.Forms.RadioButton();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.txtPrivateKeyPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFingerprint = new System.Windows.Forms.Label();
            this.txtFingerprint = new System.Windows.Forms.TextBox();
            this.lblSSHPwd = new System.Windows.Forms.Label();
            this.txtSSHPwd = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.lblMySQLUser = new System.Windows.Forms.Label();
            this.txtMySQLUser = new System.Windows.Forms.TextBox();
            this.lblMySQLPassword = new System.Windows.Forms.Label();
            this.txtMySQLPassword = new System.Windows.Forms.TextBox();
            this.lblBackupFolder = new System.Windows.Forms.Label();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbIP
            // 
            this.cmbIP.Location = new System.Drawing.Point(152, 12);
            this.cmbIP.Name = "cmbIP";
            this.cmbIP.Size = new System.Drawing.Size(204, 20);
            this.cmbIP.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 15);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(101, 12);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "Linux Server IP:";
            // 
            // lblSSHUser
            // 
            this.lblSSHUser.AutoSize = true;
            this.lblSSHUser.Location = new System.Drawing.Point(12, 45);
            this.lblSSHUser.Name = "lblSSHUser";
            this.lblSSHUser.Size = new System.Drawing.Size(83, 12);
            this.lblSSHUser.TabIndex = 2;
            this.lblSSHUser.Text = "SSH Username:";
            // 
            // txtSSHUser
            // 
            this.txtSSHUser.Location = new System.Drawing.Point(152, 42);
            this.txtSSHUser.Name = "txtSSHUser";
            this.txtSSHUser.Size = new System.Drawing.Size(204, 21);
            this.txtSSHUser.TabIndex = 3;
            this.txtSSHUser.Text = "root";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 75);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(59, 12);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "SSH Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(152, 72);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(204, 21);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "22";
            // 
            // groupBoxAuth
            // 
            this.groupBoxAuth.Controls.Add(this.rdoRSA);
            this.groupBoxAuth.Controls.Add(this.rdoPassword);
            this.groupBoxAuth.Location = new System.Drawing.Point(12, 100);
            this.groupBoxAuth.Name = "groupBoxAuth";
            this.groupBoxAuth.Size = new System.Drawing.Size(344, 45);
            this.groupBoxAuth.TabIndex = 6;
            this.groupBoxAuth.TabStop = false;
            this.groupBoxAuth.Text = "SSH Authentication Method";
            // 
            // rdoRSA
            // 
            this.rdoRSA.AutoSize = true;
            this.rdoRSA.Checked = true;
            this.rdoRSA.Location = new System.Drawing.Point(10, 20);
            this.rdoRSA.Name = "rdoRSA";
            this.rdoRSA.Size = new System.Drawing.Size(131, 16);
            this.rdoRSA.TabIndex = 0;
            this.rdoRSA.TabStop = true;
            this.rdoRSA.Text = "RSA Authentication";
            this.rdoRSA.UseVisualStyleBackColor = true;
            this.rdoRSA.CheckedChanged += new System.EventHandler(this.AuthMethod_CheckedChanged);
            // 
            // rdoPassword
            // 
            this.rdoPassword.AutoSize = true;
            this.rdoPassword.Location = new System.Drawing.Point(152, 20);
            this.rdoPassword.Name = "rdoPassword";
            this.rdoPassword.Size = new System.Drawing.Size(161, 16);
            this.rdoPassword.TabIndex = 1;
            this.rdoPassword.Text = "Password Authentication";
            this.rdoPassword.UseVisualStyleBackColor = true;
            this.rdoPassword.CheckedChanged += new System.EventHandler(this.AuthMethod_CheckedChanged);
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(12, 155);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(131, 12);
            this.lblPrivateKey.TabIndex = 7;
            this.lblPrivateKey.Text = "RSA Private Key File:";
            // 
            // txtPrivateKeyPath
            // 
            this.txtPrivateKeyPath.Location = new System.Drawing.Point(152, 152);
            this.txtPrivateKeyPath.Name = "txtPrivateKeyPath";
            this.txtPrivateKeyPath.Size = new System.Drawing.Size(204, 21);
            this.txtPrivateKeyPath.TabIndex = 8;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(371, 150);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFingerprint
            // 
            this.lblFingerprint.AutoSize = true;
            this.lblFingerprint.Location = new System.Drawing.Point(12, 185);
            this.lblFingerprint.Name = "lblFingerprint";
            this.lblFingerprint.Size = new System.Drawing.Size(101, 12);
            this.lblFingerprint.TabIndex = 10;
            this.lblFingerprint.Text = "Key Fingerprint:";
            // 
            // txtFingerprint
            // 
            this.txtFingerprint.Location = new System.Drawing.Point(152, 182);
            this.txtFingerprint.Name = "txtFingerprint";
            this.txtFingerprint.Size = new System.Drawing.Size(204, 21);
            this.txtFingerprint.TabIndex = 11;
            // 
            // lblSSHPwd
            // 
            this.lblSSHPwd.AutoSize = true;
            this.lblSSHPwd.Location = new System.Drawing.Point(12, 155);
            this.lblSSHPwd.Name = "lblSSHPwd";
            this.lblSSHPwd.Size = new System.Drawing.Size(83, 12);
            this.lblSSHPwd.TabIndex = 12;
            this.lblSSHPwd.Text = "SSH Password:";
            // 
            // txtSSHPwd
            // 
            this.txtSSHPwd.Location = new System.Drawing.Point(152, 152);
            this.txtSSHPwd.Name = "txtSSHPwd";
            this.txtSSHPwd.Size = new System.Drawing.Size(204, 21);
            this.txtSSHPwd.TabIndex = 13;
            this.txtSSHPwd.UseSystemPasswordChar = true;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(12, 215);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(125, 12);
            this.lblDatabase.TabIndex = 14;
            this.lblDatabase.Text = "MySQL Database Name:";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.Location = new System.Drawing.Point(152, 212);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(204, 20);
            this.cmbDatabase.TabIndex = 15;
            // 
            // lblMySQLUser
            // 
            this.lblMySQLUser.AutoSize = true;
            this.lblMySQLUser.Location = new System.Drawing.Point(12, 245);
            this.lblMySQLUser.Name = "lblMySQLUser";
            this.lblMySQLUser.Size = new System.Drawing.Size(95, 12);
            this.lblMySQLUser.TabIndex = 16;
            this.lblMySQLUser.Text = "MySQL Username:";
            // 
            // txtMySQLUser
            // 
            this.txtMySQLUser.Location = new System.Drawing.Point(152, 242);
            this.txtMySQLUser.Name = "txtMySQLUser";
            this.txtMySQLUser.Size = new System.Drawing.Size(204, 21);
            this.txtMySQLUser.TabIndex = 17;
            this.txtMySQLUser.Text = "root";
            // 
            // lblMySQLPassword
            // 
            this.lblMySQLPassword.AutoSize = true;
            this.lblMySQLPassword.Location = new System.Drawing.Point(12, 275);
            this.lblMySQLPassword.Name = "lblMySQLPassword";
            this.lblMySQLPassword.Size = new System.Drawing.Size(131, 12);
            this.lblMySQLPassword.TabIndex = 18;
            this.lblMySQLPassword.Text = "MySQL Login Password:";
            // 
            // txtMySQLPassword
            // 
            this.txtMySQLPassword.Location = new System.Drawing.Point(152, 272);
            this.txtMySQLPassword.Name = "txtMySQLPassword";
            this.txtMySQLPassword.Size = new System.Drawing.Size(204, 21);
            this.txtMySQLPassword.TabIndex = 19;
            this.txtMySQLPassword.UseSystemPasswordChar = true;
            // 
            // lblBackupFolder
            // 
            this.lblBackupFolder.AutoSize = true;
            this.lblBackupFolder.Location = new System.Drawing.Point(12, 305);
            this.lblBackupFolder.Name = "lblBackupFolder";
            this.lblBackupFolder.Size = new System.Drawing.Size(89, 12);
            this.lblBackupFolder.TabIndex = 20;
            this.lblBackupFolder.Text = "Backup Folder:";
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Location = new System.Drawing.Point(152, 302);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(204, 21);
            this.txtBackupFolder.TabIndex = 21;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(371, 300);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(90, 23);
            this.btnBrowseOutput.TabIndex = 22;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(150, 329);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(256, 329);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(100, 30);
            this.btnBackup.TabIndex = 24;
            this.btnBackup.Text = "Start Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.Black;
            this.rtbLog.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbLog.Location = new System.Drawing.Point(12, 375);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(449, 213);
            this.rtbLog.TabIndex = 25;
            this.rtbLog.Text = "";
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(473, 600);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.txtBackupFolder);
            this.Controls.Add(this.lblBackupFolder);
            this.Controls.Add(this.txtMySQLPassword);
            this.Controls.Add(this.lblMySQLPassword);
            this.Controls.Add(this.txtMySQLUser);
            this.Controls.Add(this.lblMySQLUser);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtSSHPwd);
            this.Controls.Add(this.lblSSHPwd);
            this.Controls.Add(this.txtFingerprint);
            this.Controls.Add(this.lblFingerprint);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPrivateKeyPath);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.groupBoxAuth);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtSSHUser);
            this.Controls.Add(this.lblSSHUser);
            this.Controls.Add(this.cmbIP);
            this.Controls.Add(this.lblIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linux MySQL Backup Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBoxAuth.ResumeLayout(false);
            this.groupBoxAuth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
