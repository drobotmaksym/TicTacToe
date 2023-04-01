using TicTacToe.Model;
using TicTacToe.Model.Event;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class InputHandler
{
    private readonly View.View _primaryView;

    public InputHandler(View.View primaryView)
    {
        _primaryView = primaryView;
    }
    
    public void ReceiveAndHandleInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Position position = new(Console.CursorLeft, Console.CursorTop);
        KeyPressEvent keyPressEvent = new(keyInfo, position);
        _primaryView.OnKeyPress(keyPressEvent);
    }
}