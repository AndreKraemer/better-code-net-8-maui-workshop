namespace ElVegetarianoFurio.Menu;

[QueryProperty(nameof(Category), nameof(Category))]
public partial class CategoryPage : ContentPage
{
    private readonly CategoryViewModel _viewModel;

    public Category Category { get; set; }

    public CategoryPage(CategoryViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.Initialize(Category);
        base.OnNavigatedTo(args);
    }
}