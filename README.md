# Folder Monitoring and SFTP Push

This project provides a solution for monitoring a folder and automatically pushing any new files to an SFTP server (windows only).

## Features

- **Folder Monitoring**: Continuously monitors a specified folder for new files.
- **SFTP Push**: Automatically transfers any new files to the configured SFTP server.
- **Customizable Configuration**: Easily configure the folder to monitor, SFTP server details, and other settings.

## Usage

1. **Prepare the Monitored Folder**: Ensure the folder you want to monitor is set up with appropriate permissions.

2. **Run the command in your command prompt**: windows-watchfolder.exe \<folder-to-monitor\> \<username\> \<password\> \<sftp-host\>

3. **Monitor Output**: The script will continuously monitor the specified folder and push any new files to the configured SFTP server.

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit).

## Acknowledgements

- **[SSH.NET](https://github.com/sshnet/SSH.NET)**: A SSH library for .NET, used for SFTP communication.
