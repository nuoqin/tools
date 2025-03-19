using System.Diagnostics;
/***
 * 
 *  CMD执行器
 * */
namespace nuoqin.src.utils
{
    public class CmdUtils
    {

        public static string exec(string cmd)
        {

            using (var process = new Process())
            {
                process.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = " /c " + cmd;
                process.Start();
                var str = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
                return str;
            }
        }


    }
}
