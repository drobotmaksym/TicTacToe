using TicTacToe.Model;
using TicTacToe.Model.Event;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class KeyNavigator
{
    public static void Navigate(KeyPressEvent keyPressEvent, Component component)
    {
        Position cursorPosition = keyPressEvent.Position;

        switch (keyPressEvent.KeyInfo.Key)
        {
            case ConsoleKey.W:
                if (cursorPosition.Y != component.Position.Y) cursorPosition.Y--;
                break;
            case ConsoleKey.A:
                if (cursorPosition.X != component.Position.X) cursorPosition.X--;
                break;
            case ConsoleKey.S:
                if (cursorPosition.Y != 
                    component.Position.Y + 
                    component.Dimension.Height - 1) cursorPosition.Y++;
                break;
            case ConsoleKey.D:
                if (cursorPosition.X != 
                    component.Position.X + 
                    component.Dimension.Width - 1) cursorPosition.X++;
                break;
        }
        
        Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
    }
}