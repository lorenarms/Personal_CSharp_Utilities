
// parses CMD prompts to run from a C# application

using System.Diagnostics;

namespace CommandPromptParse
{
    internal class CmdPromptParse
    {
        static void Main(string[] args)
        {

            var startInfo = new ProcessStartInfo
            {
                //FileName = @"C:\Users\Lawrence\Desktop\play_vid.bat",
                FileName = "cmd.exe",
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                //Arguments = "/C ipconfig & Query session & cd C:\\Users\\Lawrence\\Downloads\\PSTools & dir & ",
                //Arguments = "/C hostname",
                Arguments = 
                    // "/C cd C:\\Users\\Lawrence\\Desktop\\ " +
                "/C start vlc.exe --fullscreen intro_video.mp4 " +
                "& timeout /T 10" +
                "& taskkill /IM vlc.exe /F",

                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            };
            var process = new Process { StartInfo = startInfo };

            process.Start();
            // Now read the value, parse to int and add 1 (from the original script)
            string online = process.StandardOutput.ReadToEnd();
            Console.WriteLine(online);

            //var activeLoc = online.IndexOf("Active");

            //int i = activeLoc - 3;

            //string sessionId = online.Substring(i, 3);
            //sessionId.Trim();


            Console.WriteLine("Session ID: " + online);

            process.CloseMainWindow();
            //Environment.Exit(0);

        }
    }
}