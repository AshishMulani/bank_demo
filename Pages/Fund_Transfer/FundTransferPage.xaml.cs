using Microsoft.Maui.Controls;
using bank_demo.ViewModels.FeaturesPages.FundTransfer;
using bank_demo.Models;


namespace bank_demo.Pages.Fund_Transfer;

public partial class FundTransferPage : ContentPage
{
	public FundTransferPage()
	{
		InitializeComponent();

        // Tap "Add Beneficiary"
        //BindingContext = new FundTransferViewModel(Navigation);

    }
    private async void OnAddBeneficiaryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddBeneficiaryPage(fromFundTransferPage: true));
    }

    private async void OnBeneficiarySelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Beneficiary selected)
        {
            await Navigation.PushAsync(new EnterAmountPage(selected)); // ✅ Pass the selected beneficiary directly
        }

        // Deselect the item after navigating
        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }
    }




}