using static QRCoder.PayloadGenerator;

namespace bank_demo.Pages.PaymentsFolder;

[QueryProperty(nameof(PhoneNumber), "phone")]
public partial class SendMoneyPage : ContentPage
{
    public string PhoneNumber { get; set; }

    public SendMoneyPage()
	{
		InitializeComponent();
	}

     
}