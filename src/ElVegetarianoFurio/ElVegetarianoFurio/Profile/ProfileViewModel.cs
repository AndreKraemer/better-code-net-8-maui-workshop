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
        private readonly IProfileService _profileService;
        public ProfileViewModel(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
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
            try
            {
                IsBusy = true;
                var profile = await _profileService.GetAsync();
                FullName = profile.FullName;
                Street = profile.Street;
                Zip = profile.Zip;
                City = profile.City;
                Phone = profile.Phone;
            }
            finally
            {
                IsBusy = false;
            }

        }


        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task Save()
        {
            try
            {
                IsBusy = true;
                var profile = new Profile
                {
                    FullName = FullName,
                    Street = Street,
                    Zip = Zip,
                    City = City,
                    Phone = Phone
                };
                await _profileService.SaveAsync(profile);
            }
            finally
            {
                IsBusy = false;
            }
        }


        private bool CanSave()
        {
            return !IsBusy
                && !string.IsNullOrEmpty(FullName);
        }
    }
}
