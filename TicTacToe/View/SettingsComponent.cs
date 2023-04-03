using TicTacToe.Model.Board;
using TicTacToe.Model.Game;

namespace TicTacToe.View;

public class SettingsComponent : Container
{
    public override IEnumerable<string> Represent()
    {
        Console.Clear();

        string firstPlayerName = PromptName("Enter first player name: ", "Player One");
        char firstPlayerPiece = PromptPiece("Enter first player piece (X, for instance): ");
        string secondPlayerName = PromptName("Enter second player name: ", "Player Two");
        char secondPlayerPiece = PromptPiece("Enter second player piece (O, for instance): ");
        int boardSize = PromptBoardSize("Enter board size: ", 3);

        Console.Clear();
        
        Player[] players = new[]
        {
            new Player(firstPlayerName, firstPlayerPiece),
            new Player(secondPlayerName, secondPlayerPiece)
        };
        
        TicTacToe.Game = new Game(players, players[0], new GameBoard(boardSize));
        
        return base.Represent();
    }

    private static string PromptName(string text, string defaultName)
    {
        Console.Write(text);
        return Console.ReadLine() ?? defaultName;
    }

    private static char PromptPiece(string text)
    {
        Console.Write(text);
        char piece = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return piece;
    }

    private static int PromptBoardSize(string text, int defaultSize)
    {
        Console.Write(text);
        int.TryParse(Console.ReadLine(), out int boardSize);
        if (boardSize < defaultSize) boardSize = defaultSize;
        return boardSize;
    }
}