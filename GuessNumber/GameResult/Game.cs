using NumGameSOLID.GuessNumber.ConsoleUI;
using NumGameSOLID.GuessNumber.RandomNumberGenerator;
using NumGameSOLID.GuessNumber.Services;
using NumGameSOLID.GuessNumber.Settings;

namespace NumGameSOLID.GuessNumber.GameResult;

public class Game 
{
    private readonly INumberGenerator _numberGenerator;
    private readonly Statistics _statistics;
    private readonly IGameView _gameView;
    private readonly GameSettings _gameSettings;




    private int _secretNum;
    private int _attempts;

    public Game(INumberGenerator numberGenerator, Statistics statistics, IGameView gameView, GameSettings gameSettings)
    {
        _numberGenerator = numberGenerator;
        _statistics = statistics;
        _gameView = gameView;
        _gameSettings = gameSettings;
        
    }

    public void Start()
    {

        _secretNum = _numberGenerator.Generate(_gameSettings.MinNumber, _gameSettings.MaxNumber+1);
        _attempts = 0;

        _gameView.ShowMessage($"Угадай число от {_gameSettings.MinNumber} до {_gameSettings.MaxNumber}");

        while (true)
        {
            _gameView.ShowMessage("Введите число: ");

            if (!int.TryParse(_gameView.ReadInput(), out int userNumber)) 
            { _gameView.ShowMessage("Введите корректное число!"); 
                continue; }

            if(userNumber < _gameSettings.MinNumber || userNumber > _gameSettings.MaxNumber) 
            { _gameView.ShowMessage($"Неверное число\n Число должно быть от {_gameSettings.MinNumber} до {_gameSettings.MaxNumber}");
                continue;}            

            _attempts++;
            

            if (userNumber > _secretNum) { _gameView.ShowMessage("|Загаданное число меньше|"); }

            else if (userNumber < _secretNum) { _gameView.ShowMessage("|Загаданное число больше|"); }

            
            if (userNumber == _secretNum)
            { 
                _gameView.ShowMessage($"Поздравляю, ты угадал число за {_attempts} попыток");
                _statistics.AddGame(_attempts);
                _gameView.ShowMessage($"Статистика: \n" +
                $"Игр сыграно: {_statistics.GamePlayed}\n" +
                $"Среднее количество попыток: {_statistics.AvgAttemps:F2}\n" +
                $"Минимальное количество попыток: {_statistics.MinAttemps}\n" +
                $"Максимальное количество попыток: {_statistics.MaxAttemps}");
                break;
                
            }
            else if (_attempts >= _gameSettings.MaxAttempts)
            {
                _gameView.ShowMessage($"Вы проиграли! Загаданное число: {_secretNum}");
                _statistics.AddGame(_attempts);
                _gameView.ShowMessage($"Статистика: \n" +
                $"Игр сыграно: {_statistics.GamePlayed}\n" +
                $"Среднее количество попыток: {_statistics.AvgAttemps:F2}\n" +
                $"Минимальное количество попыток: {_statistics.MinAttemps}\n" +
                $"Максимальное количество попыток: {_statistics.MaxAttemps}");
                break;
            }

            _gameView.ShowMessage($"Осталось попыток: {_gameSettings.MaxAttempts - _attempts}");
            
        }
    }
}
