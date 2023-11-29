namespace ElVegetarianoFurio.Profile;

public partial class ProfilePage : ContentPage
{
    private ProfileViewModel _viewModel;

    public ProfilePage()
	{
		InitializeComponent();
        BindingContext = _viewModel = new ProfileViewModel();
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.Initialize();
        base.OnNavigatedTo(args);
    }
}