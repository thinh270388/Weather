using Weather.Mobile.ViewModels;

namespace Weather.Mobile.Views;

public partial class WeatherPage : ContentPage
{
    public WeatherPage(WeatherViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}