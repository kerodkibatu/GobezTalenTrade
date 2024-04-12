namespace GobezTalenTrade.Models;

public record Skill(User owner,string Title, string Description, string Level, List<string> Tags, decimal Price, string Photo);
public enum SkillLevel
{
    Easy,
    Medium,
    Hard
}