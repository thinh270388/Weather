using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Weather.Mobile.Services.Constracts;

namespace Weather.Mobile.Services.Implementations
{
    public class ToastService : IToastService
    {
        public async Task ShowToast(string message)
        {
            var toast = Toast.Make(message);
            await toast.Show();
        }

        public async Task ShowSnackbar(string message, string actionText = "OK")
        {
            var snackbar = Snackbar.Make(message, () => {
                // Xử lý khi người dùng nhấn action
            }, actionText);
            await snackbar.Show();
        }

        public async Task ShowAlert(string title, string message, string button = "OK")
        {
            await Application.Current!.MainPage!.DisplayAlert(title, message, button);
        }

        public async Task<bool> ShowConfirmation(string title, string message, string acceptText = "Yes", string cancelText = "No")
        {
            return await Application.Current!.MainPage!.DisplayAlert(title, message, acceptText, cancelText);
        }        
    }
}
