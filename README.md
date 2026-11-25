# ProgramTechnology

classDiagram
direction TB

namespace NumGameSOLID {

    class Game {
        -INumberGenerator _numberGenerator
        -Statistics _statistics
        -GameSettings _gameSettings
        -bool _isStarted
        -bool _isGameOver
        -int _secretNum
        -int _attempts
        +Start() void
        +Guess(userNumber) GuessResult
    }

    class GuessResult {
        +string Message
        +bool IsGameOver
        +int AttemptsLeft
    }

    class INumberGenerator {
        <<interface>>
        +Generate(min, max) int
    }

    class RandomGenerator {
        -Random _random
        +Generate(min, max) int
    }

    class Statistics {
        -int _gamePlayed
        -int _totalAttempts
        -int _maxAttempts
        -int _minAttempts
        +TotalAttempts int
        +AddGame(attempts) void
        +AvgAttempts double
        +MinAttempts int
        +MaxAttempts int
        +GamePlayed int
    }

    class GameSettings {
        +MinNumber int
        +MaxNumber int
        +MaxAttempts int
        +GameSettings(difficulty)
    }

    class IDifficulty {
        <<interface>>
        +MinNumber int
        +MaxNumber int
        +MaxAttempts int
    }

    class EasyDifficulty
    class MediumDifficulty
    class HardDifficulty

    class User {
        +Login string
        +Statistics Statistics
    }

    class UserService {
        -Dictionary _users
        -IUserStorage _storage
        +FindUser(login) User
        +RegisterUser(login) User
        +SaveUsers() void
    }

    class IUserStorage {
        <<interface>>
        +LoadUsers() List~User~
        +SaveUsers(users) void
    }

    class UserFileStorage {
        -string _filePath
        +LoadUsers() List~User~
        +SaveUsers(users) void
    }
}

namespace NumGameSOLID_Console {

    class Program {
        +Main(args) void
    }
}

INumberGenerator <|.. RandomGenerator

IDifficulty <|.. EasyDifficulty
IDifficulty <|.. MediumDifficulty
IDifficulty <|.. HardDifficulty

IUserStorage <|.. UserFileStorage

Game --> INumberGenerator : uses
Game --> Statistics : updates
Game --> GameSettings : uses
Game ..> GuessResult : returns

GameSettings --> IDifficulty : receives

User *-- Statistics : owns

UserService --> IUserStorage : uses
UserService o-- User : manages

UserFileStorage ..> User : loads and saves

Program ..> Game : creates
Program ..> UserService : creates
Program ..> UserFileStorage : creates
Program ..> RandomGenerator : creates
Program ..> GameSettings : creates
