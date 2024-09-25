namespace Module03Exercise01.View
{
    public partial class OfflinePage : ContentPage
    {
        public OfflinePage()
        {
            InitializeComponent();
        }

        private async void OnRetryConnectionClicked(object sender, EventArgs e)
        {
            var app = Application.Current as App;
            await app.CheckConnectivityAndNavigate();
        }
    }
}
