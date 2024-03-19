using System.Diagnostics;
using System.Runtime.InteropServices;

namespace windows_watchfolder;

static class Program
{
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;
    const int SW_SHOW = 5;

    static void Main()
    {
        var handle = GetConsoleWindow();

        ShowWindow(handle, SW_HIDE);

        string[] args = Environment.GetCommandLineArgs();
        new WatchFolder.WatchFolder(args[1], args[2], args[3], args[4]);
    }
}