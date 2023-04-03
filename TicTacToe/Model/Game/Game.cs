using TicTacToe.Model.Board;

namespace TicTacToe.Model.Game;

public class Game
{
    private readonly Player[] _players;

    public Game(Player[] players, Player startingPlayer, GameBoard gameBoard)
    {
        _players = players;
        GameBoard = gameBoard;
        Statistics = new Statistics(players);
        CurrentPlayer = startingPlayer;
    }

    public GameBoard GameBoard { get; }

    public Statistics Statistics { get; }

    public Player CurrentPlayer { get; private set; }

    public GameState GameState { get; set; }

    public bool Running { get; private set; }

    public static event Action? GameRestarted;

    public void Start()
    {
        GameState = GameState.Intermediate;
        Running = true;
    }

    public void Stop()
    {
        Running = false;
    }

    public void Restart()
    {
        Stop();
        GameBoard.Clear();
        GameRestarted?.Invoke();
        Start();
    }

    public void SwitchPlayer()
    {
        int currentPlayerIndex = GetCurrentPlayerIndex();

        if (currentPlayerIndex + 1 == _players.Length)
            currentPlayerIndex = 0;
        else
            currentPlayerIndex++;

        CurrentPlayer = _players[currentPlayerIndex];
    }

    private int GetCurrentPlayerIndex()
    {
        for (int i = 0; i < _players.Length; i++)
            if (_players[i] == CurrentPlayer)
                return i;

        throw new KeyNotFoundException();
    }
}