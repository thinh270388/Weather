using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Mobile.Services.Constracts
{
    public interface ILoadingService
    {
        Task ShowLoadingAsync(string message = "Loading...");
        Task HideLoadingAsync();
    }
}
