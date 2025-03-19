using Newtonsoft.Json;
using nuoqin.src.entity;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace nuoqin.src.utils
{
    public class CustomToolsUtils
    {
        //加载
        public static CustomizeData LoadCustomizeFunction()
        {
            var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dirPath = customizeFunctionFolderPath + "\\nuoqin";
            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                File.SetAttributes(dirPath, directoryInfo.Attributes | FileAttributes.Hidden);
            }
            var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
            //判断文件是否存在
            if (!File.Exists(jsonFile))
            {
                File.WriteAllText(jsonFile, "{\r\n  \"list\":[\r\n     { \"title\":\"Navicat2\",\"description\":\"数据库管理软件\",\"commond\":\"E:\\\\tools\\\\Navicat Premium 12\\\\navicat.exe\"}\r\n  ]\r\n}");
                return null;
            }
            string jsonStr = File.ReadAllText(jsonFile, Encoding.UTF8);
            if (string.IsNullOrEmpty(jsonStr))
            {
                return null;
            }
            CustomizeData data = JsonConvert.DeserializeObject<CustomizeData>(jsonStr);
            return data;
        }

        public static Boolean BuildNewFile()
        {
            var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
            File.Delete(jsonFile);
            File.WriteAllText(jsonFile, "{\r\n  \"list\":[\r\n     { \"title\":\"Navicat2\",\"description\":\"数据库管理软件\",\"commond\":\"E:\\\\tools\\\\Navicat Premium 12\\\\navicat.exe\"}\r\n  ]\r\n}");
            OpenConfigExecute();
            return true;
        }


        public static void OpenConfigExecute()
        {
            var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
            // 使用 Process.Start 打开记事本并加载文件
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = jsonFile,
                UseShellExecute = false,
                CreateNoWindow = false
            };
            Process.Start(psi);
        }

    }
}
