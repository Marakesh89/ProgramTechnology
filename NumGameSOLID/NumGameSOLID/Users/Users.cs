using NumGameSOLID.GuessNumber.Services;

namespace NumGameSOLID.Users;

public class User
{
    public string Login { get; }
    public Statistics Statistics { get; }

    public User(string login, Statistics statistics)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            throw new ArgumentException("Логин не может быть пустым");
        }

        Login = login;
        Statistics = statistics;
    }
}