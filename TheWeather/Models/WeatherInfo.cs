using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheWeather.Models;

public class WeatherInfo : INotifyPropertyChanged
{
    private string _degree = "0 °";
    public string Degree
    {
        get => _degree;
        set => SetProperty(ref _degree, value);
    }
    private string _weather;
    public string Weather
    {
        get => _weather;
        set => SetProperty(ref _weather, value);
    }
    private string _weatherFirst = "./Assets/default.png";
    public string WeatherFirst
    {
        get => _weatherFirst;
        set => SetProperty(ref _weatherFirst, value);
    }
    private string _windDirectionName;
    public string WindDirectionName
    {
        get => _windDirectionName;
        set => SetProperty(ref _windDirectionName, value);
    }
    private string _windPower;
    public string WindPower
    {
        get => _windPower;
        set => SetProperty(ref _windPower, value);
    }
    private string _cityInfo = "暂无网络";
    public string CityInfo
    {
        get => _cityInfo;
        set => SetProperty(ref _cityInfo, value);
    }
    private string _province ;
    public string Province
    {
        get => _province;
        set => SetProperty(ref _province, value);
    }
    private string _county ;
    public string County
    {
        get => _county;
        set => SetProperty(ref _county, value);
    }
    private string _city ;
    public string City
    {
        get => _city;
        set => SetProperty(ref _city, value);
    }

    
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}