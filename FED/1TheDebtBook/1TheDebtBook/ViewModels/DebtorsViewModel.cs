using _1TheDebtBook.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _1TheDebtBook.ViewModels
{
    public partial class DebtorsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Debtor> _debtors;

        public DebtorsViewModel()
        {
            Debtors = _debtors;
            _database = new Database();
            _ = Initialize();
        }

        private readonly Database _database;

        private async Task Initialize()
        {
            var debtorViews = await _database.GetDebtors();
            foreach (var debtorView in debtorViews)
            {
                Debtors.Add(debtorView);
            }
        }
    }
}
