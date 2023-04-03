namespace TicTacToe.Model.Game;

public class Player
{
    public Player(string name, char piece)
    {
        Name = name;
        Piece = piece;
    }

    public string Name { get; set; }

    public char Piece { get; set; }
}