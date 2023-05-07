
// works with "PanIQVideoPlayer_V2" ClientSlave app
// 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Command_Runner
    {
        public void StartIntroVideo()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = false,  // setting this to 'false' allows for 'timeout /T' to work as arg
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                Arguments = "/C start vlc.exe --fullscreen --no-video-title-show --no-qt-fs-controller intro_video.mp4 " +
                            "& timeout /T 10" +
                            "& taskkill /IM vlc.exe /F",

                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            };
            var process = new Process { StartInfo = startInfo };

            process.Start();


            process.CloseMainWindow();

        }

        public void StopIntroVideo()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = false,  // setting this to 'false' allows for 'timeout /T' to work as arg
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                Arguments = "/C taskkill /IM vlc.exe",

                WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized,
            };
            var process = new Process { StartInfo = startInfo };

            process.Start();

            process.CloseMainWindow();
        }


        // Takes in a <List> of CMD commands, parses to a string
        // and then runs the commands

        public string RunCommandWithReturn(List<string> command)
        {
            string result = string.Empty;
            string commands = string.Empty;

            foreach (var item in command)
            {
                commands += item;
                commands += " & ";
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = false,  // setting this to 'false' allows for 'timeout /T' to work as arg
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                Arguments = commands,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            };
            var process = new Process { StartInfo = startInfo };

            process.Start();

            result = process.StandardOutput.ReadToEnd();
            result = result.ToString().TrimEnd('\r', '\n');

            //process.CloseMainWindow();

            return result;

        }
    }
}
