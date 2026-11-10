using NumGameSOLID.GuessNumber.ConsoleUI;
using NumGameSOLID.GuessNumber.RandomNumberGenerator;
using NumGameSOLID.GuessNumber.Services;

namespace NumGameSOLID.GuessNumber.GameResult;

public class Game 
{
    private readonly INumberGenerator _numberGenerator;
    private readonly Statistics _statistics;
    private readonly IGameView _gameView;


    private int _secretNum;
    private int _attempts;

    public Game(INumberGenerator numberGenerator, Statistics statistics, IGameView gameView)
    {
        _numberGenerator = numberGenerator;
        _statistics = statistics;
        _gameView = gameView;
    }

    public void Start()
    {
        _secretNum = _numberGenerator.Generate(1, 101);
        _attempts = 0;

        _gameView.ShowMessage("Угадай число от 1 до 100");

        while (true)
        {
            _gameView.ShowMessage("Введите число: ");

            if (!int.TryParse(_gameView.ReadInput(), out int userNumber)) 
            { _gameView.ShowMessage("Введите корректное число!"); 
                continue; }

            if(userNumber < 1 || userNumber > 100) 
            { _gameView.ShowMessage("Неверное число\n Число должно быть от 1 до 100");
                continue;}

            _attempts++;
            if (userNumber > _secretNum) { _gameView.ShowMessage("Загаданное число меньше"); }

            else if (userNumber < _secretNum) { _gameView.ShowMessage("Загаданное число больше"); }            
            
            else { _gameView.ShowMessage($"Поздравляю, ты угадал число за {_attempts} попыток");
                _statistics.AddGame(_attempts);                
                break;
            }
            

        }
    }
}
