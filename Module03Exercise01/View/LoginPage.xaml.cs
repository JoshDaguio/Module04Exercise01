using Microsoft.Maui.Controls;
using Module03Exercise01.Services;

namespace Module03Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly IMyService _myService; //Field for the service
        public LoginPage(IMyService myService)
        {
            InitializeComponent();
            _myService = myService;

            var message = _myService.GetMessage();
            MyLabel.Text = message;

        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Assuming EmployeePage is a valid page
            await Navigation.PushAsync(new EmployeePage());
        }
    }
}
