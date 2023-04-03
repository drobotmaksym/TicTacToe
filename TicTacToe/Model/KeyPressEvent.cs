namespace TicTacToe.Model.Event;

public class KeyPressEvent
{
    public KeyPressEvent(ConsoleKeyInfo keyInfo, Position position)
    {
        KeyInfo = keyInfo;
        Position = position;
    }

    public ConsoleKeyInfo KeyInfo { get; }

    public Position Position { get; }
}