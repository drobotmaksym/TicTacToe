using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoxComponent : Component
{
    public BoxComponent(Box box)
    {
        Rectangle.Dimension = new Dimension(1, 1);
        Box = box;
    }

    public Box Box { get; }

    public override IEnumerable<string> Represent()
    {
        switch (Box.Piece)
        {
            case Box.Empty:
                ForegroundColor = ConsoleColor.DarkGray;
                break;
            default:
                ForegroundColor = ConsoleColor.Cyan;
                break;
        }

        return new[] { Box.Piece.ToString() };
    }
}