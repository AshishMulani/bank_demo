using bank_demo.Services;

namespace bank_demo.Pages
{
    public partial class BeneficiaryStatusPage : ContentPage
    {
        public Beneficiary SelectedBeneficiary { get; set; }

        public BeneficiaryStatusPage(Beneficiary beneficiary)
        {
            InitializeComponent();
            SelectedBeneficiary = beneficiary;

            // Optionally bind the beneficiary data to UI elements
            BindingContext = this; // Set this page's data context to the passed data
        }
    }
}
