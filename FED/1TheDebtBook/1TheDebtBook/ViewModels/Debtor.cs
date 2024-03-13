using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using _1TheDebtBook.Data;

namespace _1TheDebtBook.ViewModels
{
    public partial class Debtor : ObservableObject
    {
        public Debtor()
        {
            _database = new Database();
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ViewName))]
        string name;

        public string ViewName => $"{Name}";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ViewAmount))]
        double amount;

        public double ViewAmount => Amount;

        [RelayCommand]
        public async Task AddDebtorView()
        {
            Debtor debtor = new Debtor();
            debtor.Name = Name;
            debtor.Amount = Amount;
            await _database.AddDebtor(debtor);
            Name = "";
            Amount = 0.0;
        }

        private readonly Database _database;
        private DebtorsViewModel _debtorsViewModel;
    }
}

