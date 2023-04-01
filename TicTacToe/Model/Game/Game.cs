namespace TicTacToe.Model.Game;

public class Game
{
    private readonly Player[] _players;
    
    public Statistics Statistics { get; }
    
    public Player CurrentPlayer { get; private set; }
    
    public GameState GameState { get; set; }

    public Game(Player[] players, Player startingPlayer)
    {
        _players = players;
        Statistics = new Statistics(players);
        CurrentPlayer = startingPlayer;
    }
    
    public void Start()
    {
        GameState = GameState.Intermediate;
    }
    
    public void Stop()
    {
        GameState = GameState.Stopped;
    }

    public void SwitchPlayer()
    {
        int currentPlayerIndex = GetCurrentPlayerIndex();
        
        if (currentPlayerIndex + 1 == _players.Length)
        {
            currentPlayerIndex = 0;
        }
        else
        {
            currentPlayerIndex++;
        }

        CurrentPlayer = _players[currentPlayerIndex];
    }

    private int GetCurrentPlayerIndex()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] == CurrentPlayer) return i;
        }

        throw new KeyNotFoundException();
    }
}