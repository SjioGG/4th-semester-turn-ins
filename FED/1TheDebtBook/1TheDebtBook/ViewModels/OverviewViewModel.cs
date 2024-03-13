using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _1TheDebtBook.ViewModels;

[QueryProperty("Text", "Text")]

public partial class OverviewViewModel : ObservableObject
{
    [ObservableProperty]
    string text;
}