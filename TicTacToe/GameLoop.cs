using TicTacToe.Controller;

namespace TicTacToe;

public class GameLoop
{
    private readonly InputHandler _inputHandler;
    private readonly GameRenderer _gameRenderer;
    private bool _running;

    public GameLoop(InputHandler inputHandler, GameRenderer gameRenderer)
    {
        _inputHandler = inputHandler;
        _gameRenderer = gameRenderer;
    }
    
    internal void Start()
    {
        _running = true;
        _gameRenderer.Init();
        EnterLoop();
    }

    private void EnterLoop()
    {
        while (_running)
        {
            _gameRenderer.Render();
            _inputHandler.ReceiveAndHandleInput();
        }
    }
    
    internal void Stop()
    {
        _running = false;
    }
}