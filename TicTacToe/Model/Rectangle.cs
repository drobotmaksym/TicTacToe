namespace TicTacToe.Model;

public struct Rectangle
{
    public Position Position { get; set; }
    
    public Dimension Dimension { get; set; }

    public Rectangle(Position position, Dimension dimension)
    {
        Position = position;
        Dimension = dimension;
    }

    public bool Contains(Position position)
    {
        return position.X >= Position.X &&
               position.X <= Position.X + Dimension.Width &&
               position.Y >= Position.Y &&
               position.Y <= Position.Y + Dimension.Height;
    }

    public override string ToString()
    {
        return $"X: {Position.X}, Y: {Position.Y}, " +
               $"W: {Dimension.Width}, H: {Dimension.Height}";
    }
}