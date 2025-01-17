using Weather.Mobile.ViewModels;

namespace Weather.Mobile.Views;

public partial class SettingPage : ContentPage
{
	private readonly SettingViewModel _viewModel;
	public SettingPage(SettingViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		Task.Run(async() => await _viewModel.LoadSettings()).Wait();
    }
}