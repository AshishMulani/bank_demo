using System.Collections.ObjectModel;
using bank_demo.Services; // if TransactionModel is defined there

namespace bank_demo.Services
{
    public static class TransactionStore
    {
        public static ObservableCollection<TransactionModel> AllTransactions { get; } = new ObservableCollection<TransactionModel>();
    }
}
