using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.Controller;

public class InputReceiver
{
    public static KeyPressEvent ReceiveInput()
    {
        Position cursorPosition = new Position(
            Console.CursorLeft,
            Console.CursorTop
            );
        
        return new KeyPressEvent(
            Console.ReadKey(true),
            cursorPosition
        );
    }
}