using TicTacToe.Model.Game;

namespace TicTacToe.View;

public class StatisticsComponent : Component
{
    private Statistics _statistics;

    public StatisticsComponent(Statistics statistics)
    {
        _statistics = statistics;
        ForegroundColor = ConsoleColor.Blue;
    }

    public override IEnumerable<string> Represent()
    {
        string[] representation = new string[_statistics.Players.Count + 1];
        
        representation[0] = $"Ties: {_statistics.Ties}";

        int currentIndex = 1;
        foreach (Player player in _statistics.Players)
        {
            representation[currentIndex] = $"{player.Name}: {_statistics.GetNumberOfWinsFor(player)}";
            currentIndex++;
        }
        
        return representation;
    }
}