namespace TicTacToe.Model.Event;

public class KeyPressEvent : Event
{
    public ConsoleKeyInfo KeyInfo { get; }
    
    public Position Position { get; }

    public KeyPressEvent(ConsoleKeyInfo keyInfo, Position position)
    {
        KeyInfo = keyInfo;
        Position = position;
    }
}