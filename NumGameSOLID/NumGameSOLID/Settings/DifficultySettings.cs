namespace NumGameSOLID.GuessNumber.Settings;

public class DifficultySettings
{
    public GameSettings GetSettings(Difficulty difficulty)
    {
                switch (difficulty)
        {
            case Difficulty.Easy:
                return new GameSettings(1, 50, 10, Difficulty.Easy);
            case Difficulty.Medium:
                return new GameSettings(1, 100, 7, Difficulty.Medium);
            case Difficulty.Hard:
                return new GameSettings(1, 200, 5, Difficulty.Hard);
            default:
                throw new ArgumentException("Invalid difficulty level.");
        }
    }
}
