using System.Text;
using TicTacToe.Controller;
using TicTacToe.Model.Game;
using TicTacToe.View;

namespace TicTacToe;

public sealed class TicTacToe
{
    internal static GameLoop GameLoop;
    public static Game Game = null!;
    private static readonly Component _root;
    private static readonly GameLogic _gameLogic;

    static TicTacToe()
    {
        new SettingsComponent().Represent(); // Creates a game

        _root = new RootComponent(Game);
        _gameLogic = new GameLogic(Game);

        GameLoop = new GameLoop(_root, Game);
    }

    public static void Main(string[] args)
    {
        Console.Title = "Tic-Tac-Toe | WASD to navigate | Enter to place a piece";
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        new PressHandlerSubscriber(_gameLogic, _root).SubscribePressHandlers();

        GameLoop.Start();
    }
}