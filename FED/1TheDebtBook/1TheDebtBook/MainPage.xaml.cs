using _1TheDebtBook.Pages;
using _1TheDebtBook.ViewModels;
using _1TheDebtBook.Data;
using System.Collections.ObjectModel;


namespace _1TheDebtBook
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new DebtorsViewModel();
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the new page or window
            await Navigation.PushAsync(new AddPage());
        }
    }
}
