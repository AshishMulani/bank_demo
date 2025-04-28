using bank_demo.ViewModels.FeaturesPages;

namespace bank_demo.Pages;

public partial class BeneficiaryStatusPage : ContentPage
{
    public BeneficiaryStatusPage()
    {
        InitializeComponent();
        BindingContext = new BeneficiaryStatusViewModel();
    }
}

