using TicTacToe.Model;
using TicTacToe.Model.Game;

namespace TicTacToe.View;

public class RootComponent : Container
{
    public Game Game { get; }
    public static ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
    public static ConsoleColor DefaultForegroundColor = ConsoleColor.White;
    
    public RootComponent(Game game)
    {
        AddChild(new StatisticsComponent(game.Statistics));
        AddChild(new BoardComponent(game.GameBoard));

        Rectangle.Dimension = new Dimension(25, 25);
            
        Game = game;
    }
}