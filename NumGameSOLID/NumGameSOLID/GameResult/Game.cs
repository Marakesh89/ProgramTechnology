using NumGameSOLID.GuessNumber.RandomNumberGenerator;
using NumGameSOLID.GuessNumber.Services;
using NumGameSOLID.GuessNumber.Settings;
using NumGameSOLID.Models;

namespace NumGameSOLID.GuessNumber.GameResult;

public class Game 
{
    private readonly INumberGenerator _numberGenerator;
    private readonly Statistics _statistics;
    private readonly GameSettings _gameSettings;
    private bool _isGameOver;



    private int _secretNum;
    private int _attempts;

    public Game(INumberGenerator numberGenerator, Statistics statistics,  GameSettings gameSettings)    
    {
        _numberGenerator = numberGenerator;
        _statistics = statistics;
       
        _gameSettings = gameSettings;
        
    }

    
    public void Start()
    {
        _secretNum = _numberGenerator.Generate(_gameSettings.MinNumber, _gameSettings.MaxNumber + 1);
        _attempts = 0;
        _isGameOver = false;
    }

    public GuessResult Guess(int userNumber)
    {
        if(_isGameOver)
        {
            return new GuessResult(
                "Игра уже завершена",
                true,
                0);
        }

        if (userNumber < _gameSettings.MinNumber || userNumber > _gameSettings.MaxNumber)
        {
            return new GuessResult(
                "Неверное число",
                false,
                _gameSettings.MaxAttempts - _attempts);
               
            
        }

        _attempts++;

        if (userNumber == _secretNum)
        {
            _isGameOver = true;
            return new GuessResult(
                "Поздравляю, ты угадал число!",
                true,
                _gameSettings.MaxAttempts - _attempts);
        }
        else if (_attempts >= _gameSettings.MaxAttempts)
        {
            _isGameOver = true;
            return new GuessResult(
                $"Вы проиграли! Загаданное число: {_secretNum}",
                true,
                0);
        }
        else if (userNumber < _secretNum)
        {

            return new GuessResult(
                "Загаданное число больше",
                false,
                _gameSettings.MaxAttempts - _attempts);
        }
        else
        {
            return new GuessResult(
                "Загаданное число меньше!",
                false,
                _gameSettings.MaxAttempts - _attempts);
        }
    }

    //public void Start()
    //{

    //    _secretNum = _numberGenerator.Generate(_gameSettings.MinNumber, _gameSettings.MaxNumber+1);
    //    _attempts = 0;

    //    _gameView.ShowMessage($"Угадай число от {_gameSettings.MinNumber} до {_gameSettings.MaxNumber}");


    //    while (true)
    //    {
    //        _gameView.ShowMessage("Введите число: ");

    //        if (!int.TryParse(_gameView.ReadInput(), out int userNumber)) 
    //        { _gameView.ShowMessage("Введите корректное число!"); 
    //            continue; }

    //        if(userNumber < _gameSettings.MinNumber || userNumber > _gameSettings.MaxNumber) 
    //        { _gameView.ShowMessage($"Неверное число\n Число должно быть от {_gameSettings.MinNumber} до {_gameSettings.MaxNumber}");
    //            continue;}            

    //        _attempts++;


    //        if (userNumber > _secretNum) { _gameView.ShowMessage("|Загаданное число меньше|"); }

    //        else if (userNumber < _secretNum) { _gameView.ShowMessage("|Загаданное число больше|"); }


    //        if (userNumber == _secretNum)
    //        { 
    //            _gameView.ShowMessage($"Поздравляю, ты угадал число за {_attempts} попыток");
    //            _statistics.AddGame(_attempts);
    //            _gameView.ShowStatistic(_statistics);
    //            break;

    //        }
    //        else if (_attempts >= _gameSettings.MaxAttempts)
    //        {
    //            _gameView.ShowMessage($"Вы проиграли! Загаданное число: {_secretNum}");
    //            _statistics.AddGame(_attempts);
    //            _gameView.ShowStatistic(_statistics);
    //            break;
    //        }

    //        _gameView.ShowMessage($"Осталось попыток: {_gameSettings.MaxAttempts - _attempts}");

    //    }
    //}
}
