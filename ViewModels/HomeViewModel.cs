using GobezTalenTrade.Models;
using GobezTalenTrade.Services;

namespace GobezTalenTrade.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    private readonly SkillsService skillsService;
    [ObservableProperty]
    ObservableCollection<Skill> skillsList = [];
    [ObservableProperty]
    string queryText = "";
    public HomeViewModel(SkillsService skillsService)
    {
        this.skillsService = skillsService;
    }
    [RelayCommand]
    async Task FetchSkills()
    {
        var skills = skillsService.FetchSkills();
        SkillsList.Clear();
        foreach (var skill in skills)
        {
            SkillsList.Add(skill);
        }
    }
    [RelayCommand]
    async Task SearchSkills()
    {
        if(string.IsNullOrEmpty(QueryText))
        { return; }
        var skills = skillsService.FilterSkills(QueryText);
        SkillsList.Clear();
        foreach (var skill in skills)
        {
            SkillsList.Add(skill);
        }
    }
}
