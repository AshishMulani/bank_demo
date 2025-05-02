using System.Collections.ObjectModel;
using bank_demo.Services;

namespace bank_demo.ViewModels.FeaturesPages;

public class HistoryViewModel : BaseViewModel
{
    public ObservableCollection<TransactionModel> Transactions { get; set; }

    public HistoryViewModel()
    {
        Transactions = new ObservableCollection<TransactionModel>
        {
            new TransactionModel { Description = "Paid to Rahul", Amount = 500, Date = DateTime.Today},
            new TransactionModel { Description = "Refund from Amazon", Amount = 1200, Date = DateTime.Today.AddDays(-1)},
            new TransactionModel { Description = "Grocery Shopping", Amount = 450, Date = DateTime.Today.AddDays(-2)},
            new TransactionModel { Description = "Electricity Bill", Amount = 900, Date = DateTime.Today.AddDays(-5)}
        };
    }
}
