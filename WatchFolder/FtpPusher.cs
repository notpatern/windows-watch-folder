﻿
using Renci.SshNet;
using FileStream = System.IO.FileStream;

namespace windows_watchfolder.WatchFolder;

public class FtpPusher(string username, string password, string ftpUrl)
{
    private readonly SftpClient _client = new(ftpUrl, 22, username, password);

    public void Upload(string file)
    {
        bool isFileLocked = true;
        do
        {
            try
            {
                FileStream tryStream = new FileInfo(file).Open(FileMode.Open, FileAccess.Read, FileShare.None);
                tryStream.Close();
            }
            catch (IOException)
            {
                continue;
            }
            isFileLocked = false;
        } 
        while (isFileLocked);
        
        FileStream stream = new FileStream(file, FileMode.Open);
        
        _client.Connect();
        _client.ChangeDirectory("/");
        _client.BufferSize = 4 * 1024; 
        _client.UploadFile(stream, Path.GetFileName(file));
        _client.Disconnect();
        _client.Dispose();
        
        stream.Close();
        stream.Dispose();
        File.Delete(file);
    }
}