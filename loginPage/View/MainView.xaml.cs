using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace loginPage.View
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int vMsg, int wParam, int lParam);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.StopAppAsync();
            Application.Current.Shutdown();
        }

        private void PnlControlBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
           // DragMove();
        }

        private void PnlControlBar_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            App.StopAppAsync();
            Application.Current.Shutdown();
        }

        private void BtnMax_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                /*// 记录原始大小
                double originalWidth = this.Width;
                double originalHeight = this.Height;

                // 创建 Storyboard
                Storyboard storyboard = new Storyboard();

                // 创建宽度动画
                DoubleAnimation widthAnimation = new DoubleAnimation
                {
                    From = this.Width,
                    To = SystemParameters.PrimaryScreenWidth,
                    Duration = TimeSpan.FromSeconds(1)
                };
                Storyboard.SetTarget(widthAnimation, this);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Window.WidthProperty));
                storyboard.Children.Add(widthAnimation);

                // 创建高度动画
                DoubleAnimation heightAnimation = new DoubleAnimation
                {
                    From = this.Height,
                    To = SystemParameters.PrimaryScreenHeight,
                    Duration = TimeSpan.FromSeconds(1)
                };
                Storyboard.SetTarget(heightAnimation, this);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Window.HeightProperty));
                storyboard.Children.Add(heightAnimation);

                // 动画完成后的操作
                storyboard.Completed += (s, ev) =>
                {
                    this.WindowState = WindowState.Maximized;
                };
                // 开始动画
                storyboard.Begin();*/
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void BtnMin_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
