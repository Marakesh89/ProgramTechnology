namespace NumGameSOLID.GuessNumber.Services;

internal class StatisticsStorage
{
    public bool Save(Statistics statistics)
    {
        try
        {
            using (var writer = new StreamWriter("statistics.txt"))
            {
                writer.WriteLine(statistics.GamePlayed);
                writer.WriteLine(statistics.AvgAttemps);
                writer.WriteLine(statistics.MinAttemps);
                writer.WriteLine(statistics.MaxAttemps);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
