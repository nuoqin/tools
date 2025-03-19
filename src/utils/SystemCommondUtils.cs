using nuoqin.src.entity;
using System.Collections.Generic;

namespace nuoqin.src.utils
{
    public class SystemCommondUtils
    {

        public static List<SystemModel> systemModels = new List<SystemModel>() {
            new SystemModel("计算器","calc"),
            new SystemModel("关于系统", "winver"),
            new SystemModel("注册表", "regedit"),
            new SystemModel("防火墙","firewall.cpl"),
            new SystemModel("服务管理","services.msc"),
            new SystemModel("远程控制", "mstsc"),
            new SystemModel("屏幕键盘", "osk"),
            new SystemModel("打开或关闭Windows功能", "OptionalFeatures"),
            new SystemModel("资源监视器", "Resmon"),
            new SystemModel("截图工具", "snippingtool"),
            new SystemModel("写字板", "write"),
            new SystemModel("放大镜", "magnify"),
            new SystemModel("鼠标设置", "main.cpl"),
            new SystemModel("IIS控制台", "inetmgr"),
            new SystemModel("任务计划程序", "taskschd.msc"),
            new SystemModel("本机账号", "net user"),
            new SystemModel("颜色管理", "colorcpl"),
            new SystemModel("日期和时间", "timedate.cpl"),
            new SystemModel("系统信息", "msinfo32"),
            new SystemModel("系统属性", "sysdm.cpl"),
            new SystemModel("系统配置", "Msconfig.exe"),
            new SystemModel("计算机管理", "CompMgmtLauncher"),
            new SystemModel("磁盘管理器", "diskmgmt.msc"),
            new SystemModel("设备管理器", "devmgmt.msc"),
            new SystemModel("网络适配器","ncpa.cpl"),
            new SystemModel("组件管理", "comexp.msc"),
            new SystemModel("控制面版", "control"),
            new SystemModel("打印机管理", "printmanagement.msc"),
            new SystemModel("Internet属性", "inetcpl.cpl"),
            new SystemModel("共享文件夹管理器", "fsmgmt.msc"),
            new SystemModel("组策略", "gpedit.msc"),
            new SystemModel("程序和功能", "appwiz.cpl"),
            new SystemModel("关机", "shutdown -s -t 1"),
        };




    }
}
