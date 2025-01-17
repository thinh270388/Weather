using Xamarin.Essentials;

namespace Weather.Models.Helpers
{
    public class NetworkHelper
    {
        public static bool IsNetworkAvailable()
        {
            var current = Connectivity.NetworkAccess;
            return current == NetworkAccess.Internet;
        }
    }
}
