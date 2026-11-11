namespace NumGameSOLID.GuessNumber.Services;

public class Statistics
{
    private int _gamePlayed = 0;
    private int _TotalAttemps = 0;
    private int _maxAttemps = 0;
    private int _minAttemps = int.MaxValue; 

    public void AddGame(int attemps)
    {
        _gamePlayed++;
        _TotalAttemps += attemps;
        if(attemps<_minAttemps) _minAttemps = attemps; 

        if (attemps > _maxAttemps) _maxAttemps = attemps; 
    }

    public double AvgAttemps {
        get
        {
            if (_gamePlayed == 0) return 0;
            return (double)_TotalAttemps / _gamePlayed;
        }
 
    }

    public int MinAttemps => _gamePlayed == 0 ? 0 : _minAttemps;
    public int MaxAttemps => _maxAttemps;
    public int GamePlayed => _gamePlayed;

    
    

}
