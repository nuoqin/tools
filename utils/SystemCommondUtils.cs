using code_tools.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_tools.utils
{
    public class SystemCommondUtils
    {

        public static List<SystemModel> systemModels = new List<SystemModel>() {
            new SystemModel("计算器","calc"),
            new SystemModel("注册表", "regedit"),
            new SystemModel("远程控制", "mstsc"),
            new SystemModel("屏幕键盘", "osk"),
            new SystemModel("打开或关闭Windows功能", "OptionalFeatures"),
            new SystemModel("资源监视器", "Resmon"),
            new SystemModel("截图工具", "snippingtool"),
            new SystemModel("日期和时间", "timedate.cpl"),
            new SystemModel("系统信息", "msinfo32"),
            new SystemModel("系统属性", "sysdm.cpl"),
            new SystemModel("系统配置", "Msconfig.exe"),
            new SystemModel("计算机管理", "CompMgmtLauncher"),
            new SystemModel("磁盘管理器", "diskmgmt.msc"),
            new SystemModel("设备管理器", "devmgmt.msc"),
            new SystemModel("组件管理", "comexp.msc"),
            new SystemModel("控制面版", "control"),
            new SystemModel("Internet属性", "inetcpl.cpl"),
            new SystemModel("共享文件夹管理器", "fsmgmt.msc"),
            new SystemModel("组策略", "gpedit.msc"),
            new SystemModel("程序和功能", "appwiz.cpl"),
            new SystemModel("关机", "shutdown -s -t 1"),
        };


       

    }
}
