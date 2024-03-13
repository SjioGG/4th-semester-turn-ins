using _1TheDebtBook.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using _1TheDebtBook.Models;
using System.Transactions;
using _1TheDebtBook.Pages;
using System.Xml.Linq;

namespace _1TheDebtBook.ViewModels;

[QueryProperty("Text", "Text")]

public partial class OverviewViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<dTransaction> _transactions;

    private readonly Database _database;
    public OverviewViewModel()
    {
        Transactions = new ObservableCollection<dTransaction>();
        _database = new Database();
        _ = Initialize();
    }
    private async Task Initialize()
    {
        var dTransactionViews = await _database.GetTransactions();
        foreach (var dTransactionView in dTransactionViews)
        {
            Transactions.Add(dTransactionView);
        }
    }
    [RelayCommand]
    public async Task AddTransaction()
    {
        dTransaction transaction = new dTransaction
        {
            dTransactionDate = TransDate,
            Amount = Amount
        };
        await _database.AddTransaction(transaction);
        Transactions.Add(transaction);
    }

}