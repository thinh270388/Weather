using Weather.Mobile.ViewModels;

namespace Weather.Mobile.Views;

public partial class TourismPage : ContentPage
{
	public TourismPage(TourismViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}