namespace TicTacToe.Model.Event;

public class KeyPressEvent
{
    public ConsoleKeyInfo KeyInfo { get; }
    
    public Position Position { get; }

    public KeyPressEvent(ConsoleKeyInfo keyInfo, Position position)
    {
        KeyInfo = keyInfo;
        Position = position;
    }
}