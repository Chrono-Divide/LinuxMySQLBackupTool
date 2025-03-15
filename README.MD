# LinuxMySQLBackupTool

**LinuxMySQLBackupTool** is a Windows Forms application written in C# that allows users to remotely connect to a Linux server via SSH, retrieve available MySQL databases, and perform a full backup (including both schema and data) using `mysqldump`. The application supports **RSA key-based authentication** and **password-based authentication**, and it enables users to save their configurations for future sessions.

## Features

- ✅ **SSH Connection**: Connect to a Linux server using either **RSA key authentication** or **password authentication**.
- ✅ **Host Key Verification**: Optionally verify the server’s **Host Key fingerprint** for additional security.
- ✅ **Automatic Database Retrieval**: After a successful login, the tool loads and displays the list of available MySQL databases.
- ✅ **Database Backup**: Perform a **full backup** of the selected MySQL database using `mysqldump`.
- ✅ **Backup Storage Location**: Choose the output directory where the backup file (with a timestamp) will be saved.
- ✅ **Configuration Persistence**: Save SSH and MySQL settings, along with the selected backup folder, for future use.
- ✅ **Console-Style Logging**: A RichTextBox displays logs in a console-style format with colored messages (green for success, yellow for warnings, red for errors).

## Usage

### **1. Configure Connection Settings**

- **Linux Server IP**: Enter or select the Linux server's IP address.
- **SSH Authentication**:
  - **RSA Authentication**: Choose a private key file using the **Browse** button, and optionally enter the fingerprint for verification.
  - **Password Authentication**: Enter your SSH password.
- **MySQL Credentials**:
  - **Database Name**: Automatically populated after a successful login.
  - **MySQL Username**: The default is `root`, but you can modify it.
  - **MySQL Password**: Enter the MySQL password if required.
- **Backup Folder**: Select the output directory where backup files will be saved.

### **2. Login and Backup**

1. Click **"Login"** to establish an SSH connection to the server.
2. If successful, the tool will retrieve the list of available MySQL databases.
3. Select the database you want to back up and click **"Start Backup"**.
4. The tool will execute `mysqldump` remotely and save the `.sql` backup file to the specified folder.

## Configuration Files

- **`saved_ips.txt`**: Stores previously used Linux server IP addresses.
- **`config.txt`**: Saves the current connection settings for future use.

## Troubleshooting

- **Connection Errors**: Ensure the Linux server allows SSH access and verify that the provided credentials are correct.
- **MySQL Database Not Loading**: Some MySQL 8.0+ installations use socket-based authentication, which may require logging in as `root` via SSH.
- **Backup Failures**: Ensure the MySQL user has the necessary privileges to run `mysqldump`.

## License

This project is open-source and free to use. You are welcome to modify and distribute it as needed.

## Contact & Support

If you have any issues or feature requests, please open an issue on GitHub.

---
