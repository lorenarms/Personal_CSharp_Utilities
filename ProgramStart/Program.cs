using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        //ProcessStartInfo start = new ProcessStartInfo();
        //start.Arguments = @"psexec \\192.168.0.171 -u lawrence.artl@gmail.com -p H1pp0501@mic -s -d -i 1 C:\Users\lawre\OneDrive\Desktop\play_vid.bat";
        //start.FileName = @"cmd.exe";
        ////start.WindowStyle = ProcessWindowStyle.Hidden;
        ////start.CreateNoWindow = true;
        //int exitCode;

        //using (Process proc = Process.Start(start))
        //{
        //    proc.WaitForExit();


        //    exitCode = proc.ExitCode;
        //}

        var startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process { StartInfo = startInfo };

        process.Start();
        process.StandardInput.WriteLine(@"cd C:\Users\Lawrence\Downloads\PSTools");
        process.StandardInput.WriteLine(@"psexec \\192.168.0.171 -u lawrence.artl@gmail.com -p H1pp0501@mic -s -d -i 1 C:\Users\lawre\OneDrive\Desktop\play_vid.bat");
        process.StandardInput.WriteLine("exit");



        process.WaitForExit();
    }
}