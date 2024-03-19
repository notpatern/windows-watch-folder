namespace windows_watchfolder;

static class Program
{
    static void Main(string[] args)
    {
        new WatchFolder.WatchFolder(args[0], args[1], args[2], args[3]);
    }
}