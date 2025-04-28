using bank_demo.Services;
using System.Collections.ObjectModel;
using bank_demo.Services;

namespace bank_demo.ViewModels.FeaturesPages
{
    public class BeneficiaryStatusViewModel : BaseViewModel
    {
        public ObservableCollection<Beneficiary> Beneficiaries { get; set; }

        public BeneficiaryStatusViewModel()
        {
            // Load beneficiaries from the service
            Beneficiaries = new ObservableCollection<Beneficiary>(BeneficiaryService.Beneficiaries);
        }
    }
}
