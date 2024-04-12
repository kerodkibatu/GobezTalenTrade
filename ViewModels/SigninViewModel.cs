using CommunityToolkit.Maui.Alerts;
using GobezTalenTrade.Services;

namespace GobezTalenTrade.ViewModels;

public partial class SigninViewModel(UserService userService) : BaseViewModel
{
    private readonly UserService _userService = userService;

    // Properties
    [ObservableProperty]
     string username;

    [ObservableProperty]
     string password;

    [ObservableProperty]
     string profilePicture = "avatar.png";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsSignInMode))]
    bool isSignUpMode;
    public bool IsSignInMode => ! IsSignUpMode;

    // Methods
    [RelayCommand]
    private async Task SignIn()
    {
        var user = _userService.AuthenticateUser(Username, Password);
        if (user != null)
        {
            await Toast.Make($"Signed in to {user.Username} Succesfully!").Show();
            await Shell.Current.GoToAsync("///home");
            ClearForm();
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Invalid username or password", "OK");
        }
    }

    [RelayCommand]
    private async Task SignUp()
    {
        // Perform sign up logic
        try
        {
            _userService.RegisterUser(Username, Password,ProfilePicture);
            // Set current user
            _userService.AuthenticateUser(Username, Password);

            await Toast.Make($"Succesfully created user '{Username}'!").Show();
            // Navigate to home page
            await Shell.Current.GoToAsync("///home");
            ClearForm();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"Failed to sign up!\n{ex.Message}", "OK");
        }
    }
    void ClearForm()
    {
        Username = "";
        Password = "";
        ProfilePicture = "";
        IsSignUpMode = false;
    }
    [RelayCommand]
    private async Task ChooseProfilePicture()
    {
        var mediaFile = await MediaPicker.PickPhotoAsync();

        if (mediaFile != null)
        {
            // Generate a random GUID for the file name
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Get the app's local data directory path
            var localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Combine the directory path and the file name to get the new file path
            var newFilePath = Path.Combine(localFolderPath, fileName);

            // Copy the selected file to the new file path
            using (var stream = await mediaFile.OpenReadAsync())
            {
                using (var outputStream = File.OpenWrite(newFilePath))
                {
                    await stream.CopyToAsync(outputStream);
                }
            }
            // Update the user's profile picture path
            ProfilePicture = newFilePath;
        }
    }

}
