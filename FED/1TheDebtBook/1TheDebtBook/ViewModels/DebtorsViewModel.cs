using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _1TheDebtBook
{
    public class DebtorsViewModel : ObservableObject
    {
        private ObservableCollection<Debtor> _debtors;

        public ObservableCollection<Debtor> Debtors
        {
            get { return _debtors; }
            set { SetProperty(ref _debtors, value); }
        }

        public DebtorsViewModel()
        {
            // Initialize the collection of debtors
            Debtors = new ObservableCollection<Debtor>();
            // Add sample debtors for testing
            Debtors.Add(new Debtor { Name = "John", Amount = 100.0 });
            Debtors.Add(new Debtor { Name = "Alice", Amount = 200.0 });
            Debtors.Add(new Debtor { Name = "Bob", Amount = 300.0 });
        }
    }
}
