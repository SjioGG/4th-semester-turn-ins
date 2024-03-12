namespace _1TheDebtBook.Pages;
using _1TheDebtBook.ViewModels;

public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
        BindingContext = new Debtor();
    }
}