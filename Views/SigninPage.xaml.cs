namespace GobezTalenTrade.Views;

public partial class SigninPage : ContentPage
{
	public SigninPage(SigninViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
