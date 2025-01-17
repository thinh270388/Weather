namespace Weather.Mobile.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}
    public void SetMessage(string message)
    {
        MessageLabel.Text = message;
    }
}