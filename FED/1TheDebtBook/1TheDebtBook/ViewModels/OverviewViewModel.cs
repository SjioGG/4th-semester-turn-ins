using _1TheDebtBook.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using _1TheDebtBook.Models;
using _1TheDebtBook.Pages;
using System.Threading.Tasks;


namespace _1TheDebtBook.ViewModels
{
    public partial class OverviewViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<dTransaction> _transactions;

        private readonly Database _database;

        // Property to hold the DebtorId
        [ObservableProperty]
        private int _debtorId;

        public OverviewViewModel()
        {
            Transactions = new ObservableCollection<dTransaction>();
            _database = new Database();
            _ = Initialize();
        }

        private async Task Initialize()
        {
            // Ensure DebtorId is set before retrieving transactions

                var dTransactionViews = await _database.GetTransactionsForDebtor(_debtorId);
                foreach (var dTransactionView in dTransactionViews)
                {
                    Transactions.Add(dTransactionView);
                }
            
        }

        [ObservableProperty]
        private double _inputAmount;

        [RelayCommand]
        public async Task AddTransaction()
        {
            dTransaction transaction = new dTransaction
            {
                Amount = InputAmount,
                DebtorId = DebtorId
            };
            await _database.AddTransaction(transaction);
            Transactions.Add(transaction);
        }
    }
}
