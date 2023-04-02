namespace TicTacToe.Model.Dash;

public class Dash
{
    private readonly Position[] _positions;
    
    public Orientation Orientation { get; }

    public IEnumerable<Position> Positions => _positions;

    public Dash(Orientation orientation, Position[] positions)
    {
        Orientation = orientation;
        _positions = positions;
    }
}