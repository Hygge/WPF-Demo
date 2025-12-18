using System.Net.Http;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using TheWeather.Models;

namespace TheWeather.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly HttpClient _httpClient;
    private readonly System.Timers.Timer _refreshTimer;
    public WeatherInfo weatherInfo { set; get; }

    public MainWindowViewModel()
    {
        weatherInfo = new WeatherInfo();
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", 
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
        _httpClient.DefaultRequestHeaders.Add("cookie", 
            "__v=waf; __sec_vk=1e8db051-7eef-4b2c-a976-be255106e7d8; _teapot=j8scpgtit0jehfddr68t0omve5ziun92c9la5bnlj5u983lfdxiftw2dotoprtititvgqqxylmfsa1396z0on3aa; __sec_id=_SECLygfDmhf7jg//igfzhfdzgfeyldrGoRL/Xa7nObOnWd+C3oBv9Vs62nsTCmMT8TsbBigH4itGCkg++WQbsjQ75jLPVc7HYRLGiO7WeObKePrmYNqTMbvPpcP3og6; __sec_ud=_SECLEc8bTcOHYde7NauPKb+jPbP3kgfrphq; __sec_ol=a; __sec_io=be2fb99e0da8e010a130dde48a405bcf5be151e189deab8b9592098f89d85eb21a4c0bbd22d65916ed315e9374ad24532ac5f0221193c2e5e185361a5f901e25; _uiu=vs0l6V0nfn7RBz6kXwuSRIkmzAF7ksU0wBgdinvbNKShq.fEiUuZ9Hm/QnlecVddr7=4/Ib.NaWa9RHk1boXiYr/IK/nktYFlLAGTx=EDcjBj/uymgYjyle9.Gl.Nd241kMUXgHv/E96m.f15QBe3S/pDviCCtkFGBEBy50nGnWunO4.roTUrkC42YPPViXDel.yIwy3.jLG/hbKzm6.2jtn; _iui=XcHT5UoqcsAeNVDSbBs7d1D8hoxoqdbgEVUs8J03d5lw6tPQx2nYWrz95XDPFZ8qSiUY8; _qwq=1766045323841:79f308278505f0b7ef2fd97e97163ecce55c7847263d55d3228a12c3c13de837/3890a17e556d80ef4fd22c2de21a976554abb1c2d2a3bd331888c1ec0ae3d_6c1131062e0cfb94d288b9652b59ae1e916f746f16187616e22a9522b5b");
        
        // 设置5秒刷新定时器
        _refreshTimer = new System.Timers.Timer(5000);
        _refreshTimer.Elapsed += async (s, e) => await RefreshAsync();
        _refreshTimer.Start();
    }

    private  async Task RefreshAsync()
    {
        await getLocation();
        await refreshWeatherInfo();
    }
    
    
    private async Task getLocation()
    {
        // string url = "https://iplark.com/ipcn";
        string url = "https://my.ip.cn/json/?ticket=8acd6cfda04eea0231e81c23b8cde0001765972595";
        try
        {
            string response = await _httpClient.GetStringAsync(url);
            if (string.IsNullOrEmpty(response))
            {
                weatherInfo.CityInfo = "暂无网络";
                return;
            }
            
            Dictionary<string,object>? ret = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            Dictionary<string,object>? data = JsonConvert.DeserializeObject<Dictionary<string, object>>(ret["data"].ToString());
            weatherInfo.Province = data["province"].ToString();
            weatherInfo.City = data["city"].ToString();
            weatherInfo.County = data["district"].ToString();

            weatherInfo.CityInfo = $"{weatherInfo.City} {weatherInfo.County}";
        
            Thread.Sleep(200);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
  
    }

    private async Task refreshWeatherInfo()
    {
        if (string.IsNullOrEmpty(weatherInfo.City))
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return;
        }

        try
        {
            string url = $"https://wis.qq.com/weather/common?source=pc&weather_type=observe&province={weatherInfo.Province}&city={weatherInfo.City}&county={weatherInfo.County}";
            string response = await _httpClient.GetStringAsync(url);
            if (string.IsNullOrEmpty(response)) return;

            Dictionary<string,object>? ret = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            var b = ret.TryGetValue("status", out object status);
            if (b && Convert.ToInt32(status) == 200)
            {
                Dictionary<string,object>? data = JsonConvert.DeserializeObject<Dictionary<string, object>>(ret["data"].ToString());
                Dictionary<string,object>? observe = JsonConvert.DeserializeObject<Dictionary<string, object>>(data["observe"].ToString());
                weatherInfo.Degree = observe["degree"].ToString() + "°";
                weatherInfo.Weather =  observe["weather"].ToString();
                weatherInfo.WindPower = observe["wind_power"].ToString();
                weatherInfo.WindDirectionName = observe["wind_direction_name"].ToString();
                weatherInfo.WeatherFirst = observe["weather_first"].ToString();

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
     
    }

}