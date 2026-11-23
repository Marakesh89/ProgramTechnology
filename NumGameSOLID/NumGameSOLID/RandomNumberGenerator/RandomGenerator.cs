namespace NumGameSOLID.GuessNumber.RandomNumberGenerator;

public class RandomGenerator : INumberGenerator
{
    private readonly Random _random = new Random();
    public int Generate(int min, int max)
    {
        return _random.Next(min, max);
    }
}
