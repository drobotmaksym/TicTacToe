namespace TicTacToe.Model.Game;

public class Player
{
    public string Name { get; set; }
    
    public char Piece { get; set; }

    public Player(string name, char piece)
    {
        Name = name;
        Piece = piece;
    }
}