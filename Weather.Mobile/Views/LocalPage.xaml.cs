using System.Diagnostics;
using Weather.Mobile.ViewModels;

namespace Weather.Mobile.Views;

public partial class LocalPage : ContentPage
{
    private readonly LocalViewModel _viewModel;
    public LocalPage(LocalViewModel viewModel)
	{
		InitializeComponent();

        _viewModel = viewModel;
		BindingContext = viewModel;
    }

    private async void HiddenWebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        _viewModel.StatusClay = "Đang tải dữ liệu ...";
        if (e.Result == WebNavigationResult.Success)
        {
            try
            {
                List<string> HymetnetData = new();
                string title = await HiddenWebView.EvaluateJavaScriptAsync("document.evaluate('//*[@id=\"timerenderList\"]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue?.innerText || 'Không tìm thấy dữ liệu';");
                HymetnetData.Add(title.Split("\\n")[0]);
                string content = await HiddenWebView.EvaluateJavaScriptAsync("document.querySelector('#timerenderList a')?.href || 'Không tìm thấy dữ liệu';");
                HymetnetData.Add(content);
                _viewModel.HymetnetData = HymetnetData;                
            }
            catch (Exception ex)
            {
                _viewModel.HymetnetData = null!;
                Debug.WriteLine(ex.Message);
            }
        }
    }

    private void btnRefresh_Clicked(object sender, EventArgs e)
    {
        HiddenWebView.Source = _viewModel.WebUrl;
        MsnWebView.Source = _viewModel.MsnWebUrl;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        MsnWebView.Source = _viewModel.MsnWebUrl;
    }
}