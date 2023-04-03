using System.Text;
using TicTacToe.Controller;
using TicTacToe.Model.Board;
using TicTacToe.Model.Game;
using TicTacToe.View;

namespace TicTacToe;

public sealed class TicTacToe
{
    internal static GameLoop GameLoop;
    private static Game _game;
    private static Component _root;
    private static GameLogic _gameLogic;
    
    private static Game CreateGame()
    {
        Player maksym = new Player("Maksym", 'X');
        Player natasa = new Player("Natasa", 'O');
        Player[] players = new[] { maksym, natasa };
        
        GameBoard board = new(3);
        
        return new Game(players, maksym, board);
    }

    static TicTacToe()
    {
        _game = CreateGame();
        _root = new RootComponent(_game);
        _gameLogic = new GameLogic(_game);
        
        GameLoop = new GameLoop(_root, _game);
    }
    
    public static void Main(string[] args)
    {
        Console.Title = "Tic-Tac-Toe";
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        PressHandlerSubscriber pressHandlerSubscriber = new(_gameLogic, _root);
        pressHandlerSubscriber.SubscribePressHandlers();
        
        GameLoop.Start();
    }
}