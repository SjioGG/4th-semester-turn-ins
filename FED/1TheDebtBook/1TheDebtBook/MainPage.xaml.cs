namespace _1TheDebtBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Debtor();
        }
    }
}
