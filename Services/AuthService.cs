using GobezTalenTrade.Models;

namespace GobezTalenTrade.Services;
public class UserService
{
    public readonly List<User> Users;
    public User? CurrentUser { get; private set; }
    public UserService()
    {
        Users = []; // Initialize with an empty list of users
    }

    public void RegisterUser(string username, string password,string pfp = "")
    {
        if (Users.Any(u => u.Username == username))
        {
            throw new ArgumentException("Username is already taken.");
        }

        var newUser = new User { Username = username, Password = password, ProfilePicture = pfp };
        Users.Add(newUser);
    }

    // Authenticate user
    public User AuthenticateUser(string username, string password)
    {
        var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            CurrentUser = user;
        }
        return user;
    }
    public void Logout() => CurrentUser = null; // Set the current user to null to indicate logout
    public User? GetByUserName(string userName) => Users.FirstOrDefault(x => x.Username == userName);
}
