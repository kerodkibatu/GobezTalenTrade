using CommunityToolkit.Maui.Alerts;
using GobezTalenTrade.Models;
using GobezTalenTrade.Services;

namespace GobezTalenTrade.ViewModels;

public partial class PostSkillViewModel : BaseViewModel
{
    private readonly SkillsService skillsService;
    private readonly UserService userService;

    public PostSkillViewModel(SkillsService _skillsService, UserService _userService)
    {
        skillsService = _skillsService;
        userService = _userService;
    }

    // Properties
    [ObservableProperty]
    string title;
    [ObservableProperty]
    string description;
    [ObservableProperty]
    SkillLevel level;
    [ObservableProperty]
    string tagsAsString;
    [ObservableProperty]
    decimal price;
    [ObservableProperty]
    string photo;

    [RelayCommand]
    private async Task ChoosePhoto()
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
            Photo = newFilePath;
        }
    }
    // Methods
    [RelayCommand]
    private async Task PostSkill()
    {
        skillsService.PostSkill(userService.CurrentUser!.Username, Title, Description, Level, [..TagsAsString.Split(',')], Price, Photo);
        await Snackbar.Make("Skill Posted Successfully!").Show();
    }
}