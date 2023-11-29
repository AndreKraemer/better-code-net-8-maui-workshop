using CommunityToolkit.Mvvm.ComponentModel;

using ElVegetarianoFurio.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Menu
{
    [INotifyPropertyChanged]
    public partial class CategoryViewModel
    {
        private readonly IDataService _dataService;

        public CategoryViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        [ObservableProperty]
        private Category _category;

        [ObservableProperty]
        private bool _isBusy = false;

        public ObservableCollection<Dish> Dishes{ get; } = new ObservableCollection<Dish>();


        public async Task Initialize(Category category)
        {
            try
            {
                IsBusy = true;
                Category = category;
                var dishes = await _dataService.GetDishesAsync(category.Id);

                foreach (Dish dish in dishes)
                {
                    Dishes.Add(dish);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
