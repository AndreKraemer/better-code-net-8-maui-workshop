using CommunityToolkit.Mvvm.ComponentModel;
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

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        [ObservableProperty]
        private bool _isBusy = false;

        public ObservableCollection<Category> Categories { get; } = new ObservableCollection<Category> ();

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
    }
}
