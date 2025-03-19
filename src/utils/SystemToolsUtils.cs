using nuoqin.src.entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuoqin.src.utils
{
    public class SystemToolsUtils
    {

        public static ObservableCollection<SystemTool> init()
        {
            return new ObservableCollection<SystemTool>() {
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"系统清理","系统清理软件","\\Dism++\\Dism++x64.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"ES可视化","elasticsearch可视化管理工具","\\elasticsearch\\elasticvue.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"文件搜索","文件搜索工具","\\Everything\\Everything.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"磁盘分析","系统磁盘文件分析软件","\\WizTree\\WizTree.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"系统安装","系统安装制作工具","\\UltraISO\\UltraISO.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"软件卸载","系统软件卸载工具","\\geek\\geek.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"网速查看","查看系统网速工具","\\TrafficMonitor\\TrafficMonitor.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"硬件检测","查看系统配置信息","\\HWiNFO\\HWiNFO.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"数据恢复","用于找回删除的文件","\\recuva\\recuva.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"截图工具","这是一个类似于微信截图的工具","\\PixPin\\PixPin.exe"),
                new SystemTool(Wpf.Ui.Controls.SymbolRegular.Box24,"显示器检测","显示器色域检测","\\monitorinfo\\monitorinfo .exe")
            };
        }
    }
}
