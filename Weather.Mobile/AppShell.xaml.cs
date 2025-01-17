using Weather.Mobile.Views;

namespace Weather.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            CurrentItem = tabHome;
        }
    }
}
