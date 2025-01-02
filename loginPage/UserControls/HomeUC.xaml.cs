using System.Windows.Controls;
using loginPage.Model;
using loginPage.ViewModel;

namespace loginPage.UserControls;

public partial class HomeUC : UserControl
{
    public HomeUC()
    {
        InitializeComponent();
        this.DataContext = new HomeUCViewModel();
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel() { userName = "张三", id = 22, email = "广东省廉江市车板镇大坝村" });
        tableDataGrid.Items.Add(new UserModel { userName = "李四", id = 23, email = "江西省景德镇市市辖区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
        tableDataGrid.Items.Add(new UserModel { userName = "王五", id = 24, email = "上海市虹口区" });
    }
}