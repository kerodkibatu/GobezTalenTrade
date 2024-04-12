namespace GobezTalenTrade.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void refreshView_Refreshing(object sender, EventArgs e)
    {
		refreshView.IsRefreshing = false;
    }
}
