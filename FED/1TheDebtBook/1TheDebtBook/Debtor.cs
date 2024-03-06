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

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        public bool  IsNotBusy => !IsBusy;

        [RelayCommand]
        void Tap()
        {
            IsBusy = true;

            Console.WriteLine(name, ViewName);

            IsBusy = false;
        }
    }
}
