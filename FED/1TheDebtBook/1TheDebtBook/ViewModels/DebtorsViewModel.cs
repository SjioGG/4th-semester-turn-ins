using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _1TheDebtBook
{
    public partial class DebtorsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Debtor> _debtors;

        public DebtorsViewModel()
        {
            // Initialize the collection of debtors
            Debtors =
            [
                // Add sample debtors for testing
                new Debtor { Name = "John", Amount = 100.0 },
                new Debtor { Name = "Alice", Amount = 200.0 },
                new Debtor { Name = "Bob", Amount = 300.0 },
            ];
        }
    }
}
