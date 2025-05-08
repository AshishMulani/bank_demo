using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using bank_demo.Services;
using bank_demo.Pages.PaymentsFolder;

namespace bank_demo.ViewModels.FeaturesPages.PaymentsVM
{
    public class ContactViewModel : BindableObject
    {
        public ObservableCollection<ContactModel> Contacts { get; set; }


        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact != value)
                {
                    _selectedContact = value;
                    OnPropertyChanged();

                    // Optional: auto-fill Entry field when a contact is selected
                    EnteredNumber = _selectedContact?.PhoneNumber;
                }
            }
        }

        private string _enteredNumber;

        public string EnteredNumber
        {
            get => _enteredNumber;
            set
            {
                _enteredNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand ProceedCommand { get; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>
            {
                new ContactModel { Name = "ATharv", PhoneNumber = "9999911111" },
                new ContactModel { Name = "Shubham", PhoneNumber = "9999922222" },
                new ContactModel { Name = "Ashish", PhoneNumber = "9999933333" },
            };

            ProceedCommand = new Command(async () =>
            {
                Console.WriteLine("ProceedCommand executed. Navigating to SendMoneyPage...");
                var phone = SelectedContact?.PhoneNumber ?? EnteredNumber;

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    var route = $"{nameof(SendMoneyPage)}?PhoneNumber={phone}";
                    Console.WriteLine($"Navigating to: {route}");
                    await Shell.Current.GoToAsync(route);

                }
                else
                {
                    Console.WriteLine("Missing Info: No contact or number provided.");
                    await Application.Current.MainPage.DisplayAlert("Missing Info", "Please select a contact or enter a number.", "OK");
                }

                

            });
        }
    }

    
}
