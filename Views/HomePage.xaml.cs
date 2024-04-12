namespace GobezTalenTrade.Views;

public partial class HomePage : ContentPage
{
    HomeViewModel vm;
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = vm = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        vm.FetchSkillsCommand.Execute(null);
        base.OnNavigatedTo(args);
    }
    private async void refreshView_Refreshing(object sender, EventArgs e)
    {
        await Task.Delay(1000);
        refreshView.IsRefreshing = false;
    }
}
