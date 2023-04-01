using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoardView : ObservableView<Board>
{
    public BoardView(Board model) : base(model)
    {
        for (int i = 0; i < model.Area; i++)
        {
            AddChild(new BoxView(model.GetBoxByIndex(i)));
        }
    }

    public override void Render()
    {
        Console.WriteLine("Rendering a board.");
    }
}