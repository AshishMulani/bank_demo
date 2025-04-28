using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace bank_demo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private bool _isRememberMe;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public bool IsRememberMe
        {
            get => _isRememberMe;
            set { _isRememberMe = value; OnPropertyChanged(nameof(IsRememberMe)); }
        }

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginAsync());
            SignUpCommand = new Command(async () => await SignUpAsync());
            ForgotPasswordCommand = new Command(async () => await Shell.Current.GoToAsync("ForgotPasswordPage"));

        }

        private async Task LoginAsync()
        {
            if (Username == "admin" && Password == "1234")
            {
                await Shell.Current.GoToAsync("//Home"); // Navigate to Home page
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }

        private async Task SignUpAsync()
        {
            await Shell.Current.GoToAsync("Signup"); 
        }


        private async Task ForgotPasswordAsync()
        {
            string email = await Application.Current.MainPage.DisplayPromptAsync(
                "Forgot Password",
                "Enter your email to reset your password:",
                "Send",
                "Cancel",
                placeholder: "example@email.com");

            if (string.IsNullOrWhiteSpace(email))
                return;

            // Simulate email validation logic
            if (email.ToLower().Contains("@") && email.ToLower().Contains("."))
            {
                // Simulate sending reset email
                await Application.Current.MainPage.DisplayAlert(
                    "Reset Link Sent",
                    $"A password reset link has been sent to {email}.",
                    "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Invalid Email",
                    "Please enter a valid email address.",
                    "OK");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
