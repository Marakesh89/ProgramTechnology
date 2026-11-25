using NumGameSOLID.GuessNumber.Services;

namespace NumGameSOLID.Users;

public class UserService
{
    private readonly Dictionary<string, User> _users = new();
    private readonly IUserStorage _storage;

    public UserService(IUserStorage storage)
    {
        _storage = storage;

        List<User> users = _storage.LoadUsers();

        foreach (var user in users)
        {
            if (!_users.ContainsKey(user.Login))
            {
                _users.Add(user.Login, user);
            }
        }
    }

    public User? FindUser(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            return null;
        }

        _users.TryGetValue(login, out User? user);

        return user;
    }

    public User RegisterUser(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            throw new ArgumentException("Логин не может быть пустым.");
        }

        if (_users.ContainsKey(login))
        {
            throw new InvalidOperationException("Пользователь уже существует.");
        }

        var user = new User(login, new Statistics());

        _users.Add(login, user);

        SaveUsers();

        return user;
    }

    public void SaveUsers()
    {
        _storage.SaveUsers(_users.Values.ToList());
    }
}