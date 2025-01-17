namespace Weather.Mobile.Services.Constracts
{
    public interface IToastService
    {
        Task ShowToast(string message);
        Task ShowSnackbar(string message, string actionText = "OK");
        Task ShowAlert(string title, string message, string button = "OK");
        Task<bool> ShowConfirmation(string title, string message, string acceptText = "Yes", string cancelText = "No");
    }
}
