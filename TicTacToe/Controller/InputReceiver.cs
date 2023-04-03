using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.Controller;

public class InputReceiver
{
    public static KeyPressEvent ReceiveInput()
    {
        return new KeyPressEvent(
            Console.ReadKey(true),
            new Position(
                Console.CursorLeft,
                Console.CursorTop
            )
        );
    }
}