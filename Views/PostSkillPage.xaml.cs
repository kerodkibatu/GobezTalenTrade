namespace GobezTalenTrade.Views;

public partial class PostSkillPage : ContentPage
{
	public PostSkillPage(PostSkillViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
