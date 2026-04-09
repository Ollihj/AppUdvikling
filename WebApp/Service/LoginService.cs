using Core.Models;
using WebApp.Model;

namespace WebApp.Service;

public class LoginService
{
    private List<User> mUsers;
    
    public LoginService()
    {
        mUsers = [
            new User { Name = "Anna", Password = "1234", Role = "admin" },
            new User { Name = "Signe", Password = "2345", Role="admin"},
            new User { Name="Ida", Password = "3456", Role="admin"},
            new User { Name="Frida", Password = "12345", Role="admin"}
        ];
    }

    /// <summary>
    /// Validation of credentials
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <returns>a user object if combination of username and password is known. Otherwise,
    /// it will return null</returns>
    public User? ValidLogin(string name, string password)
    {
        foreach (User u in mUsers)
            if (u.Name == name && u.Password == password)
            {
                return u;
            }
        return null;
    }
    
    public User? Register(string name, string password)
    {
        foreach (User u in mUsers)
        {
            if (u.Name == name)
                return null;
        }

        User newUser = new User { Name = name, Password = password, Role = "user" };
        mUsers.Add(newUser);
        return newUser;
    }
    
}