using System.Configuration;
using System.Data;
using System.Windows;
using Application = System.Windows.Application;

namespace TheWeather;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private NotifyIcon _notifyIcon;
    public static MainWindow _mainWindow = new MainWindow();
    protected override void OnStartup(StartupEventArgs e)
    {
        _mainWindow.ShowInTaskbar = false;
        CreateNotifyIcon();
        base.OnStartup(e);
        _mainWindow.Show();
    }

    private void CreateNotifyIcon()
    {
        _notifyIcon = new NotifyIcon
        {
            Icon = new System.Drawing.Icon("app_icon.ico"), // 添加 .ico 文件到项目
            Visible = true,
            Text = "天气小工具"
        };

        // 双击显示主窗口（可选）
        _notifyIcon.DoubleClick += (s, args) =>
        {
            _mainWindow.Show();
        };

        // 右键菜单
        var contextMenu = new ContextMenuStrip();
        contextMenu.Items.Add("显示", null, (s, args) => _mainWindow.Show());
        contextMenu.Items.Add("隐藏", null, (s, args) => _mainWindow.Hide());
        contextMenu.Items.Add("退出", null, (s, args) => Shutdown());
        _notifyIcon.ContextMenuStrip = contextMenu;
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _notifyIcon?.Dispose(); // 释放资源
        base.OnExit(e);
    }
}