using Weather.Mobile.Services.Constracts;
using Weather.Mobile.Views;

namespace Weather.Mobile.Services.Implementations
{
    public class LoadingService : ILoadingService
    {
        private IDispatcher _dispatcher;
        private LoadingPage _loadingPage = null!;

        public LoadingService(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task ShowLoadingAsync(string message = "Loading...")
        {
            await _dispatcher.DispatchAsync(async () =>
            {
                if (_loadingPage == null)
                {
                    _loadingPage = new LoadingPage();
                    await Application.Current!.MainPage!.Navigation.PushModalAsync(_loadingPage, false);
                }
                _loadingPage.SetMessage(message);
            });
        }

        public async Task HideLoadingAsync()
        {
            await _dispatcher.DispatchAsync(async () =>
            {
                if (_loadingPage != null)
                {
                    await Application.Current!.MainPage!.Navigation.PopModalAsync(false);
                    _loadingPage = null!;
                }
            });
        }
    }
}
