using GobezTalenTrade.Models;

namespace GobezTalenTrade.Services;
public class SkillsService
{
    public readonly List<Skill> Skills;
    private readonly UserService userService;

    public SkillsService(UserService userService)
    {
        Skills = []; // Initialize with an empty list of skills
        this.userService = userService;
    }
    public List<Skill> FetchSkills()
    {
        return [.. Skills.OrderBy(x => Random.Shared.Next())];
    }
    public List<Skill> FilterSkills(string Query)
    {
        return FetchSkills().FindAll(skill =>  skill.Title.Contains(Query) ||
                                        skill.Tags.Contains(Query) ||
                                        skill.Description.Contains(Query) ||
                                        skill.owner.Username.Contains(Query));
    }
    // Post a new skill
    public Skill PostSkill(string username, string title, string description, SkillLevel level, List<string> tags, decimal price, string photo)
    {
        var user = userService.GetByUserName(username) ?? throw new ArgumentException("User not found.");
        var newSkill = new Skill(user, title, description, level, tags, price, photo);
        Skills.Add(newSkill);
        return newSkill;
    }
}
