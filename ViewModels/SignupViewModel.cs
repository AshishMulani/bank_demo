using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace bank_demo.ViewModels
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(); }
        }

        public ICommand SignupCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public SignupViewModel()
        {
            SignupCommand = new Command(async () => await SignUpAsync());
            NavigateToLoginCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//LoginPage"); // Absolute route ensures reliability
            });

        }

        private async Task SignUpAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await Shell.Current.DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Shell.Current.DisplayAlert("Error", "Passwords do not match!", "OK");
                return;
            }

            await Shell.Current.DisplayAlert("Success", "Account created successfully!", "OK");
            await Shell.Current.GoToAsync("//Home");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
