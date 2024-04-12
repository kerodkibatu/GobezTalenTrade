namespace GobezTalenTrade.Models;

public record Skill(User owner,string Title, string Description, SkillLevel Level, List<string> Tags, decimal Price, string Photo);
public enum SkillLevel
{
    Easy,
    Medium,
    Hard
}