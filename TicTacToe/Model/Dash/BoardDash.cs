namespace TicTacToe.Model.Dash;

public class BoardDash
{
    public DashOrientation Orientation { get; set; }
    public int Position { get; set; }

    public BoardDash(DashOrientation orientation, int position = -1)
    {
        Orientation = orientation;
        Position = position;
    }
}