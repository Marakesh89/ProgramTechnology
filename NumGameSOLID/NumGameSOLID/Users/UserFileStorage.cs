using NumGameSOLID.Users;
using NumGameSOLID.GuessNumber.Services;

namespace NumGameSOLID.Users;

public class UserFileStorage : IUserStorage
{
    private readonly string _filePath;

    public UserFileStorage(string filePath)
    {
        _filePath = filePath;
    }

    public List<User> LoadUsers()
    {
        var users = new List<User>();

        if (!File.Exists(_filePath))
        {
            return users;
        }

        foreach (string line in File.ReadAllLines(_filePath))
        {
            string[] parts = line.Split(';');

            if (parts.Length != 5)
            {
                continue;
            }

            string login = parts[0];

            if (!int.TryParse(parts[1], out int games) ||
                !int.TryParse(parts[2], out int totalAttempts) ||
                !int.TryParse(parts[3], out int minAttempts) ||
                !int.TryParse(parts[4], out int maxAttempts))
            {
                continue;
            }

            var statistics = new Statistics(
                games,
                totalAttempts,
                minAttempts,
                maxAttempts);

            users.Add(new User(login, statistics));
        }

        return users;
    }

    public void SaveUsers(List<User> users)
    {
        var lines = new List<string>();

        foreach (var user in users)
        {
            var statistics = user.Statistics;

            string line = $"{user.Login};" +
                          $"{statistics.GamePlayed};" +
                          $"{statistics.TotalAttempts};" +
                          $"{statistics.MinAttemps};" +
                          $"{statistics.MaxAttemps}";

            lines.Add(line);
        }

        File.WriteAllLines(_filePath, lines);
    }
}