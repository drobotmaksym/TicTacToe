using TicTacToe.Controller;
using TicTacToe.Model.Event;
using TicTacToe.View;

namespace TicTacToe;

public class GameLoop
{
    private Component _rootComponent;
    private bool _running;

    public GameLoop(Component rootComponent)
    {
        _rootComponent = rootComponent;
    }
        
    internal void Start()
    {
        _running = true;
        EnterLoop();
    }

    private void EnterLoop()
    {
        Render(); // Pre-render
        
        while (_running)
        {
            HandleInput(InputReceiver.ReceiveInput());
            Render();
        }
    }

    private void HandleInput(KeyPressEvent keyPressEvent)
    {
        _rootComponent.Press(keyPressEvent);
    }
    
    private void Render()
    {
        int cursorX = Console.CursorLeft;
        int cursorY = Console.CursorTop;

        _rootComponent.Render();
        
        Console.SetCursorPosition(cursorX, cursorY);
    }
    
    internal void Stop()
    {
        _running = false;
    }
}