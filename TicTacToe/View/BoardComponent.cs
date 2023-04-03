using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoardComponent : Container
{
    public BoardComponent(GameBoard board)
    {
        Board = board;
        Rectangle = new Rectangle(
            new Position(2, 4),
            new Dimension(board.Size, board.Size)
        );

        AddChild(new DashComponent(Board));
        AddBoxes();
    }

    public GameBoard Board { get; }

    private void AddBoxes()
    {
        for (int i = 0; i < Board.Size; i++)
        for (int j = 0; j < Board.Size; j++)
        {
            BoxComponent boxComponent = new(Board[j, i]);
            boxComponent.Rectangle.Position = new Position(j, i);
            AddChild(boxComponent);
        }
    }

    public override void OnEnable()
    {
        Focus();
        base.OnEnable();
    }
}