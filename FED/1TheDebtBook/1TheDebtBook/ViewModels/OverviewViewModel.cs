using _1TheDebtBook.Data;
using _1TheDebtBook.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


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

            var dTransactionViews = await _database.GetTransactionsForDebtor(DebtorId);
            foreach (var dTransactionView in dTransactionViews)
            {
                Transactions.Add(dTransactionView);
            }

        }

        [ObservableProperty]
        double inputAmount;


        [RelayCommand]
        public async Task AddTransaction()
        {
            dTransaction transaction = new dTransaction
            {
                Amount = InputAmount
            };
            await _database.AddTransaction(transaction);
            Transactions.Add(transaction);
        }
    }