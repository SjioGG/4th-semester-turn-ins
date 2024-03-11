using _1TheDebtBook.Pages;

namespace _1TheDebtBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the new page or window
            await Navigation.PushAsync(new AddPage());
        }
    }
}
