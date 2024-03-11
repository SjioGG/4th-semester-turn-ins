using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1TheDebtBook
{
    public partial class Debtor : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ViewName))]
        string name;

        public string ViewName => $"{Name}";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ViewAmount))]
        double amount;

        public double ViewAmount => Amount;

        [RelayCommand]
        public void AddDebtor()
        {
            // Create a new debtor object using the entered name and amount
            Debtor newDebtor = new() { Name = Name, Amount = Amount };
            // Add the new debtor object to the collection or data source
            // (You need to implement this logic based on your requirements)
            // For example, you can have a collection of debtors in your view model and add the new debtor to it.
            DebtorsViewModel.Debtors.Add(newDebtor);

            // Clear the input fields after adding the debtor
            Name = "";
            Amount = 0.0;
        }
    }
}

