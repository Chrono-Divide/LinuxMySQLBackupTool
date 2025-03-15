using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace LinuxMySQLBackupTool
{
    // Notice: We do NOT redeclare rtbLog or other controls here;
    // they are declared in frmMain.Designer.cs. This avoids duplication.
    public partial class frmMain : Form
    {
        private string savedIpFile = Path.Combine(Application.StartupPath, "saved_ips.txt");
        private string configFile = Path.Combine(Application.StartupPath, "config.txt");

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Load saved Linux server IPs
            if (File.Exists(savedIpFile))
            {
                string[] ips = File.ReadAllLines(savedIpFile);
                foreach (var ip in ips)
                {
                    if (!string.IsNullOrWhiteSpace(ip))
                        cmbIP.Items.Add(ip.Trim());
                }
            }

            // Default to RSA authentication
            rdoRSA.Checked = true;
            SetAuthControls();

            // Load saved config if exists
            if (File.Exists(configFile))
            {
                var lines = File.ReadAllLines(configFile);
                foreach (var line in lines)
                {
                    if (line.StartsWith("IP="))
                        cmbIP.Text = line.Substring(3);
                    else if (line.StartsWith("SSHUser="))
                        txtSSHUser.Text = line.Substring(8);
                    else if (line.StartsWith("Port="))
                        txtPort.Text = line.Substring(5);
                    else if (line.StartsWith("AuthType="))
                    {
                        string type = line.Substring(9);
                        if (type == "RSA")
                            rdoRSA.Checked = true;
                        else
                            rdoPassword.Checked = true;
                    }
                    else if (line.StartsWith("PrivateKeyPath="))
                        txtPrivateKeyPath.Text = line.Substring(15);
                    else if (line.StartsWith("Fingerprint="))
                        txtFingerprint.Text = line.Substring(12);
                    else if (line.StartsWith("SSHPwd="))
                        txtSSHPwd.Text = line.Substring(7);
                    else if (line.StartsWith("Database="))
                        cmbDatabase.Text = line.Substring(9);
                    else if (line.StartsWith("MySQLUser="))
                        txtMySQLUser.Text = line.Substring(10);
                    else if (line.StartsWith("MySQLPassword="))
                        txtMySQLPassword.Text = line.Substring(14);
                    else if (line.StartsWith("BackupFolder="))
                        txtBackupFolder.Text = line.Substring(13);
                }
            }

            // Initially disable Backup until login is successful
            btnBackup.Enabled = false;
        }

        private void AuthMethod_CheckedChanged(object sender, EventArgs e)
        {
            SetAuthControls();
        }

        private void SetAuthControls()
        {
            bool isRSA = rdoRSA.Checked;
            // RSA controls
            lblPrivateKey.Visible = isRSA;
            txtPrivateKeyPath.Visible = isRSA;
            btnBrowse.Visible = isRSA;
            lblFingerprint.Visible = isRSA;
            txtFingerprint.Visible = isRSA;

            // Password controls
            lblSSHPwd.Visible = !isRSA;
            txtSSHPwd.Visible = !isRSA;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Choose RSA private key
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Private Key Files (*.pem;*.ppk)|*.pem;*.ppk|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPrivateKeyPath.Text = ofd.FileName;
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            // Choose backup folder
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtBackupFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
            try
            {
                using (var client = CreateSshClient())
                {
                    client.HostKeyReceived += Client_HostKeyReceived;
                    client.Connect();
                    AppendLog("SSH connection successful.", Color.LightGreen);

                    // Check OS
                    var osCmd = client.CreateCommand("uname -s");
                    string osResult = osCmd.Execute().Trim();
                    if (!osResult.Equals("Linux", StringComparison.OrdinalIgnoreCase))
                    {
                        AppendLog("Warning: Remote server might not be Linux.", Color.Yellow);
                    }
                    else
                    {
                        AppendLog("Remote server is Linux.", Color.LightGreen);
                    }

                    // Load MySQL databases
                    string mysqlUser = txtMySQLUser.Text.Trim();
                    string mysqlPwd = txtMySQLPassword.Text;
                    string showDbCmd;
                    if (string.IsNullOrEmpty(mysqlUser))
                    {
                        showDbCmd = "mysql -e \"show databases;\"";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mysqlPwd))
                            showDbCmd = $"mysql -u {mysqlUser} -p{mysqlPwd} -e \"show databases;\"";
                        else
                            showDbCmd = $"mysql -u {mysqlUser} -e \"show databases;\"";
                    }

                    AppendLog("Loading MySQL database list...", Color.White);
                    var dbCmd = client.CreateCommand(showDbCmd);
                    string dbResult = dbCmd.Execute();
                    var lines = dbResult.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lines.Length > 1)
                    {
                        cmbDatabase.Items.Clear();
                        for (int i = 1; i < lines.Length; i++)
                        {
                            cmbDatabase.Items.Add(lines[i].Trim());
                        }
                        if (cmbDatabase.Items.Count > 0)
                        {
                            cmbDatabase.SelectedIndex = 0;
                            AppendLog("MySQL databases loaded successfully.", Color.LightGreen);
                        }
                        else
                        {
                            AppendLog("No databases found.", Color.Yellow);
                        }
                    }
                    else
                    {
                        AppendLog("No database information returned.", Color.Yellow);
                    }

                    client.Disconnect();
                    AppendLog("SSH connection closed.", Color.Gray);

                    // Enable backup, disable login
                    btnLogin.Enabled = false;
                    btnBackup.Enabled = true;

                    // Optionally, save config
                    if (MessageBox.Show("Login successful. Save current configuration?",
                                        "Save Configuration",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveConfig();
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLog("Login failed: " + ex.Message, Color.Red);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            btnBackup.Enabled = false;
            rtbLog.Clear();

            try
            {
                string ip = cmbIP.Text.Trim();
                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("Please enter the Linux server IP address!");
                    return;
                }
                SaveIP(ip);

                string sshUser = txtSSHUser.Text.Trim();
                if (string.IsNullOrEmpty(sshUser))
                {
                    MessageBox.Show("Please enter the SSH username!");
                    return;
                }

                if (!int.TryParse(txtPort.Text.Trim(), out int port))
                {
                    MessageBox.Show("SSH port number is invalid!");
                    return;
                }

                bool isRSA = rdoRSA.Checked;
                if (isRSA)
                {
                    string keyPath = txtPrivateKeyPath.Text.Trim();
                    if (string.IsNullOrEmpty(keyPath) || !File.Exists(keyPath))
                    {
                        MessageBox.Show("Please select a valid RSA private key file!");
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtSSHPwd.Text))
                    {
                        MessageBox.Show("Please enter the SSH password!");
                        return;
                    }
                }

                if (cmbDatabase.SelectedItem == null)
                {
                    MessageBox.Show("Please select the MySQL database to backup!");
                    return;
                }
                string database = cmbDatabase.SelectedItem.ToString();

                string mysqlUser = txtMySQLUser.Text.Trim();
                string mysqlPassword = txtMySQLPassword.Text;

                string outputFolder = txtBackupFolder.Text.Trim();
                if (string.IsNullOrEmpty(outputFolder) || !Directory.Exists(outputFolder))
                {
                    outputFolder = Application.StartupPath;
                }

                using (var client = CreateSshClient())
                {
                    client.HostKeyReceived += Client_HostKeyReceived;
                    client.Connect();
                    AppendLog("SSH connection successful.", Color.LightGreen);

                    // Check OS
                    var osCmd = client.CreateCommand("uname -s");
                    string osResult = osCmd.Execute().Trim();
                    if (!osResult.Equals("Linux", StringComparison.OrdinalIgnoreCase))
                    {
                        AppendLog("Warning: Remote server might not be Linux. Backup may fail.", Color.Yellow);
                    }
                    else
                    {
                        AppendLog("Remote server is Linux.", Color.LightGreen);
                    }

                    // Build mysqldump command with --databases option to include CREATE DATABASE and USE statements
                    string dumpCommand;
                    if (string.IsNullOrEmpty(mysqlUser))
                    {
                        dumpCommand = $"mysqldump --databases {database}";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mysqlPassword))
                            dumpCommand = $"mysqldump -u {mysqlUser} -p{mysqlPassword} --databases {database}";
                        else
                            dumpCommand = $"mysqldump -u {mysqlUser} --databases {database}";
                    }

                    AppendLog("Starting MySQL database backup...", Color.White);

                    var cmd = client.CreateCommand(dumpCommand);
                    string result = cmd.Execute();

                    if (!string.IsNullOrEmpty(cmd.Error))
                    {
                        AppendLog("Error during backup: " + cmd.Error, Color.Red);
                    }
                    else
                    {
                        string backupFile = Path.Combine(outputFolder,
                            $"{database}_{DateTime.Now:yyyyMMddHHmmss}.sql");
                        File.WriteAllText(backupFile, result);
                        AppendLog("Backup successful! File saved to: " + backupFile, Color.LightGreen);
                    }

                    client.Disconnect();
                    AppendLog("SSH connection closed.", Color.Gray);
                }
            }
            catch (Exception ex)
            {
                AppendLog("An error occurred: " + ex.Message, Color.Red);
            }
            finally
            {
                btnBackup.Enabled = true;
            }
        }

        private SshClient CreateSshClient()
        {
            string ip = cmbIP.Text.Trim();
            int port = int.Parse(txtPort.Text.Trim());
            string sshUser = txtSSHUser.Text.Trim();
            bool isRSA = rdoRSA.Checked;

            if (isRSA)
            {
                string keyPath = txtPrivateKeyPath.Text.Trim();
                PrivateKeyFile pkFile = new PrivateKeyFile(keyPath);
                var connInfo = new ConnectionInfo(ip, port, sshUser,
                    new PrivateKeyAuthenticationMethod(sshUser, pkFile));
                return new SshClient(connInfo);
            }
            else
            {
                string pwd = txtSSHPwd.Text;
                var connInfo = new ConnectionInfo(ip, port, sshUser,
                    new PasswordAuthenticationMethod(sshUser, pwd));
                return new SshClient(connInfo);
            }
        }

        private void Client_HostKeyReceived(object sender, HostKeyEventArgs e)
        {
            string expectedFingerprint = txtFingerprint.Text.Trim().Replace(":", "").ToLower();
            if (!string.IsNullOrEmpty(expectedFingerprint))
            {
                string receivedFingerprint = BitConverter.ToString(e.FingerPrint).Replace("-", "").ToLower();
                if (!receivedFingerprint.Equals(expectedFingerprint))
                {
                    e.CanTrust = false;
                    MessageBox.Show("Host key fingerprint verification failed! Connection aborted.");
                }
                else
                {
                    e.CanTrust = true;
                }
            }
            else
            {
                e.CanTrust = true;
            }
        }

        private void SaveIP(string ip)
        {
            if (!cmbIP.Items.Contains(ip))
            {
                cmbIP.Items.Add(ip);
                File.AppendAllLines(savedIpFile, new[] { ip });
            }
        }

        private void SaveConfig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("IP=" + cmbIP.Text.Trim());
            sb.AppendLine("SSHUser=" + txtSSHUser.Text.Trim());
            sb.AppendLine("Port=" + txtPort.Text.Trim());
            sb.AppendLine("AuthType=" + (rdoRSA.Checked ? "RSA" : "Password"));
            if (rdoRSA.Checked)
            {
                sb.AppendLine("PrivateKeyPath=" + txtPrivateKeyPath.Text.Trim());
                sb.AppendLine("Fingerprint=" + txtFingerprint.Text.Trim());
            }
            else
            {
                sb.AppendLine("SSHPwd=" + txtSSHPwd.Text);
            }
            sb.AppendLine("Database=" + cmbDatabase.Text.Trim());
            sb.AppendLine("MySQLUser=" + txtMySQLUser.Text.Trim());
            sb.AppendLine("MySQLPassword=" + txtMySQLPassword.Text);
            sb.AppendLine("BackupFolder=" + txtBackupFolder.Text.Trim());
            File.WriteAllText(configFile, sb.ToString());
            MessageBox.Show("Configuration saved.");
        }

        private void AppendLog(string text, Color color)
        {
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText(text + Environment.NewLine);
            // Reset color for subsequent text
            rtbLog.SelectionColor = rtbLog.ForeColor;
        }
    }
}
