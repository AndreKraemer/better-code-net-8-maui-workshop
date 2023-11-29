using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElVegetarianoFurio.Core;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElVegetarianoFurio
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
        }

        [ObservableProperty]
        private bool _isBusy = false;

        public ObservableCollection<Category> Categories { get; } = new ObservableCollection<Category>();

        public async Task Initialize()
        {
            try
            {
                IsBusy = true;
                var categories = await _dataService.GetCategoriesAsync();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async void NavigateToCategory(Category category)
        {
            var navigationParams = new Dictionary<string, object>
            {
                {nameof(CategoryPage.Category),category}
            };
            await _navigationService.GoToAsync(nameof(CategoryPage), navigationParams);
        }
    }
}
