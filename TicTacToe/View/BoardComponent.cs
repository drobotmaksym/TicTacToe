using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoardComponent : Component
{
    private GameBoard _board;

    public BoardComponent(GameBoard board)
    {
        _board = board;
        AddBoxes();
    }

    private void AddBoxes()
    {
        for (int i = 0; i < _board.Size; i++)
        {
            for (int j = 0; j < _board.Size; j++)
            {
                BoxComponent boxComponent = new BoxComponent(_board[i, j]);
                boxComponent.Position = new Position(i, j);
                AddChild(boxComponent);
            }
        }
    }

    public override IEnumerable<string> Represent()
    {
        return EmptyContainer;
    }
}