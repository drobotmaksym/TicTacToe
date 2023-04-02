using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoardView : ObservableView<Board>
{
    public BoardView(Board board) : base(board)
    {
        Rectangle.Dimension = new Dimension(board.Size, board.Size);
        AddChildBoxes();
    }

    private void AddChildBoxes()
    {
        for (int i = 0; i < Model.Area; i++)
        {
            Position boxPosition = new(i % Model.Size, i / Model.Size);
            
            BoxView boxView = new(Model.GetBoxByIndex(i));
            boxView.Rectangle.Position = boxPosition;
            
            AddChild(boxView);
        }
    }
    
    public override void Render()
    {
        Console.WriteLine("Rendering a board.");
    }
}