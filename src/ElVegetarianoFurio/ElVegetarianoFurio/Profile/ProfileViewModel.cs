using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Profile
{
    [INotifyPropertyChanged]
    public partial class ProfileViewModel
    {
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [ObservableProperty]
        private string _fullName = string.Empty;

        [ObservableProperty]
        private string _street = string.Empty;

        [ObservableProperty]
        private string _zip = string.Empty;


        [ObservableProperty]
        private string _city = string.Empty;

        [ObservableProperty]
        private string _phone = string.Empty;

        [ObservableProperty]
        private bool _isBusy = false;


        public async Task Initialize()
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;
        }


        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task Save()
        {
            IsBusy = true;
            await Task.Delay(3000); // Simulieren eines Speichervorgangs
            IsBusy = false;
        }


        private bool CanSave()
        {
            return !IsBusy 
                && !string.IsNullOrEmpty(FullName);
        }
    }
}
