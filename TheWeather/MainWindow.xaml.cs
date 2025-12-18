using System.Text;
using System.Windows;
using System.Windows.Input;
using TheWeather.ViewModels;
using Application = System.Windows.Application;

namespace TheWeather;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainWindowViewModel();
    }

    private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton ==  MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
    private void MenuItem_OnClick_Hide(object sender, RoutedEventArgs e)
    {
        App._mainWindow.Hide();
    }
}