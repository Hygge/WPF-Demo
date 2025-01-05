using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GenshinImpactHome.Models;
using System.Collections.ObjectModel;

namespace GenshinImpactHome.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<City> Citys { get; private set; }

    public string BgImg { private set; get; } = string.Empty;

    public RelayCommand<int> SelectedMenu { private set; get; }

    public MainWindowViewModel()
    {
        Citys = new ();
        Citys.Add (new City() { iChanId = 727, sTitle = "蒙德城", sBgmUrl = "https://uploadstatic.mihoyo.com/contentweb/20200211/2020021114220951905.jpg" });
        Citys.Add (new City() { iChanId = 728, sTitle = "璃玥港", sBgmUrl = "https://uploadstatic.mihoyo.com/contentweb/20200515/2020051511072867344.jpg" });
        Citys.Add (new City() { iChanId = 729, sTitle = "稻妻城", sBgmUrl = "https://uploadstatic.mihoyo.com/contentweb/20210719/2021071917030766463.jpg" });
        Citys.Add (new City() { iChanId = 730, sTitle = "须弥城", sBgmUrl = "https://webstatic.mihoyo.com/upload/contentweb/2022/08/15/04d542b08cdee91e5dabfa0e85b8995e_8653892990016707198.jpg" });
        Citys.Add (new City() { iChanId = 731, sTitle = "枫丹廷", sBgmUrl = "https://act-webstatic.mihoyo.com/upload/contentweb/hk4e/34ec75c9ed70f793cdd698ad1a4764e5_731983624099835302.jpg" });
        Citys.Add (new City() { iChanId = 936, sTitle = "纳塔", sBgmUrl = "https://fastcdn.mihoyo.com/content-v2/hk4e/125194/9d508712aeb195be8336bd737d464f39_6390783574046371997.jpg" });

        BgImg = Citys[0].sBgmUrl;

        SelectedMenu = new RelayCommand<int>(selectedMenu);

    }

    private void selectedMenu(int iChanId)
    {
        City c = Citys.First(c => c.iChanId == iChanId);

        BgImg = c.sBgmUrl;

    }


}
