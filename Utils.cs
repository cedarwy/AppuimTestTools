using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppuimTestTools
{
    public static class Utils
    {
        public static string GetDevice(string path)
        {
            string result = "";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path + "\\adb.exe";
            //要执行的程序名称
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            //可能接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;
            //由调用程序获取输出信息
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "devices";
            //不显示程序窗口
            p.Start();

            result += p.StandardOutput.ReadToEnd();
            //p.BeginOutputReadLine();
            p.WaitForExit();
            while (p.ExitCode != 0)
            {
                result += p.StandardOutput.ReadToEnd();
                Thread.Sleep(200);
            }
            p.Close();
            return result;
        }
        public static void GetScreenShot(string path,string filename)
        {
            //string result = "";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path + "\\adb.exe";
            //要执行的程序名称
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            //可能接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;
            //由调用程序获取输出信息
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "shell /system/bin/screencap -p /sdcard/" + filename;
            //不显示程序窗口
            p.Start();

            //result += p.StandardOutput.ReadToEnd();
            //p.BeginOutputReadLine();
            p.WaitForExit();
            while (p.ExitCode != 0)
            {
                //result += p.StandardOutput.ReadToEnd();
                //Thread.Sleep(200);
            }
            p.Close();
            return;
        }
        public static void SaveScreenShot(string path, string filename,string savepath)
        {
            //string result = "";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = path + "\\adb.exe";
            //要执行的程序名称
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            //可能接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;
            //由调用程序获取输出信息
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "pull /sdcard/"+filename+" " + savepath + "\\" + filename;
            //不显示程序窗口
            p.Start();

            //result += p.StandardOutput.ReadToEnd();
            //p.BeginOutputReadLine();
            p.WaitForExit();
            while (p.ExitCode != 0)
            {
                //result += p.StandardOutput.ReadToEnd();
                //Thread.Sleep(200);
            }
            Thread.Sleep(500);
            p.Close();
            return;
        }
    }
    public enum TestCaseStatus
    {
        通过测试,
        验证测试
    }
}
