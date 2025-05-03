using System.Collections.ObjectModel;
using System.ComponentModel;
using bank_demo.Services;
using System.Runtime.CompilerServices;

namespace bank_demo.ViewModels.FeaturesPages;



public class HistoryViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TransactionModel> Transactions { get; set; }

    private ObservableCollection<TransactionModel> _filteredTransactions;
    public ObservableCollection<TransactionModel> FilteredTransactions
    {
        get => _filteredTransactions;
        set
        {
            _filteredTransactions = value;
            OnPropertyChanged();
        }
    }

    private DateFilterType _filterType = DateFilterType.All;
    public DateFilterType FilterType
    {
        get => _filterType;
        set
        {
            if (_filterType != value)
            {
                _filterType = value;
                OnPropertyChanged();
                ApplyDateFilter();
            }
        }
    }

    private DateTime _customDate = DateTime.Today;
    public DateTime CustomDate
    {
        get => _customDate;
        set { _customDate = value; OnPropertyChanged(); ApplyDateFilter(); }
    }

    public int SelectedFilterIndex
    {
        get => (int)_filterType;
        set
        {
            FilterType = (DateFilterType)value;
            OnPropertyChanged();
        }
    }


    public HistoryViewModel()
    {
        Transactions = new ObservableCollection<TransactionModel>
        {
            new TransactionModel { Description = "Paid to Rahul", Amount = 500, Date = DateTime.Today },
            new TransactionModel { Description = "Refund from Amazon", Amount = 1200, Date = DateTime.Today.AddDays(-1) },
            new TransactionModel { Description = "Grocery Shopping", Amount = 450, Date = DateTime.Today.AddDays(-2) },
            new TransactionModel { Description = "Electricity Bill", Amount = 900, Date = DateTime.Today.AddDays(-5) },
            new TransactionModel { Description = "Electricity Bill", Amount = 900, Date = DateTime.Today.AddDays(-5) }
        };

        ApplyDateFilter();
    }

    private void ApplyDateFilter()
    {
        IEnumerable<TransactionModel> filtered = Transactions;

        switch (FilterType)
        {
            case DateFilterType.LastWeek:
                filtered = Transactions.Where(t => t.Date >= DateTime.Today.AddDays(-7));
                break;
            case DateFilterType.LastMonth:
                filtered = Transactions.Where(t => t.Date >= DateTime.Today.AddMonths(-1));
                break;
            case DateFilterType.Custom:
                filtered = Transactions.Where(t => t.Date.Date == CustomDate.Date);
                break;
            case DateFilterType.All:
            default:
                break;
        }

        FilteredTransactions = new ObservableCollection<TransactionModel>(filtered);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
