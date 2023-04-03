

using TicTacToe.Controller;
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
        _rootComponent.Render(); // Pre-render
        
        while (_running)
        {
            var pressEvent = InputReceiver.ReceiveInput();
            _rootComponent.Press(pressEvent);
            _rootComponent.Render();
        }
    }
    
    internal void Stop()
    {
        _running = false;
    }
}