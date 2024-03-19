using System.Net;

namespace windows_watchfolder.WatchFolder
{
    using System.IO;
    public class WatchFolder
    {
        private readonly string _folder;
        private readonly string _username;
        private readonly string _password;
        private readonly string _ftpUrl;
        private readonly FileSystemWatcher _watcher;
        public WatchFolder(string folder, string username, string password, string ftpUrl)
        {
            _folder = folder;
            _username = username;
            _password = password;
            _ftpUrl = ftpUrl;

            _watcher = new FileSystemWatcher(_folder);

            Init();
            Console.ReadLine();
        }

        private void Init()
        {
            _watcher.NotifyFilter = NotifyFilters.FileName;

            _watcher.Created += OnCreated;

            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }


        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            var pusher = new FtpPusher(_username, _password, _ftpUrl);
            pusher.Upload(e.FullPath);
        }
    }
}
