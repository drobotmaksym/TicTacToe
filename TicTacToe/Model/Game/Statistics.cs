namespace TicTacToe.Model.Game;

public class Statistics
{
    private readonly Dictionary<Player, int> _playerStatistics = new();
    
    public int Ties { get; private set; }

    public Statistics(Player[] players)
    {
        foreach (Player player in players)
        {
            _playerStatistics.Add(player, 0);
        }
    }
    
    public void IncreaseWinsFor(Player player)
    {
        _playerStatistics.TryGetValue(player, out int currentScore);
        
        currentScore += 1;
        
        if (_playerStatistics.ContainsKey(player))
        {
            _playerStatistics[player] = currentScore;
        }
        else
        {
            _playerStatistics.Add(player, currentScore);
        }
    }

    public void IncreaseTies()
    {
        Ties++;
    }
}