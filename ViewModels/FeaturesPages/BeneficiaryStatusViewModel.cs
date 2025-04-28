using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace bank_demo.ViewModels.FeaturesPages
{
    public class BeneficiaryStatusViewModel
    {
        public ICommand ListBeneficiaryCommand { get; }

        public BeneficiaryStatusViewModel()
        {
            ListBeneficiaryCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("///BeneficiaryListPage");
            });
        }
    }
}
