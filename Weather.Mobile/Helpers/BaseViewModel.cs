using CommunityToolkit.Mvvm.ComponentModel;

namespace Weather.Mobile.Helpers
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public bool isBusy;

        [ObservableProperty]
        public string title = string.Empty;

        public bool IsNotBusy => !IsBusy;
    }
}
