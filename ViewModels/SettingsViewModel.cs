using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using GobezTalenTrade.Services;
using Microsoft.Maui.Controls;

namespace GobezTalenTrade.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly UserService _userService;

        public SettingsViewModel(UserService userService)
        {
            _userService = userService;

            // Populate properties with user data from UserService
            UpdateUserData();
        }

        // Properties
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string userProfilePicture;

        [RelayCommand]
        private async void Logout()
        {
            _userService.Logout();
            //await Shell.Current.Navigation.PopToRootAsync(); // Navigate to the root page
            await Shell.Current.GoToAsync("///signin"); // Navigate to the sign in page
        }

        [RelayCommand]
        private void UpdateUserData()
        {
            var currentUser = _userService.CurrentUser;
            if (currentUser != null)
            {
                Username = currentUser.Username;
                UserProfilePicture = currentUser.ProfilePicture;
            }
        }
    }
}
