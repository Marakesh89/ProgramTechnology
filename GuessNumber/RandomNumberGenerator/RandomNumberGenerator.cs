namespace NumGameSOLID.GuessNumber.Interfaces;

public class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _random = new Random();
    public int Generate(int max, int min)
    {
        return _random.Next(min, max);
    }
}
