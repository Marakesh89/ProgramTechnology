namespace NumGameSOLID.GuessNumber.Services;

public class Statistics
{
    private int _gamePlayed = 0;
    private int _totalAttemps = 0;
    private int _maxAttemps = 0;
    private int _minAttemps = int.MaxValue;
    public int TotalAttempts => _totalAttemps;

    public Statistics(int gamePlayed, int totalAttempts, int minAttempts, int maxAttempts)
    {
        _gamePlayed = gamePlayed;
        _totalAttemps = totalAttempts;
        _minAttemps = minAttempts;
        _maxAttemps = maxAttempts;
    }

    public Statistics()
    {

    }

    public void AddGame(int attemps)
    {
        _gamePlayed++;
        _totalAttemps += attemps;
        if(attemps<_minAttemps) _minAttemps = attemps; 

        if (attemps > _maxAttemps) _maxAttemps = attemps; 
    }

    public double AvgAttemps {
        get
        {
            if (_gamePlayed == 0) return 0;
            return (double)_totalAttemps / _gamePlayed;
        }
 
    }

    public int MinAttemps => _gamePlayed == 0 ? 0 : _minAttemps;
    public int MaxAttemps => _maxAttemps;
    public int GamePlayed => _gamePlayed;

    
    

}
