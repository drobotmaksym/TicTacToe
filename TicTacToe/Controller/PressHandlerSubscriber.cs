using TicTacToe.View;

namespace TicTacToe.Controller;

public class PressHandlerSubscriber
{
    private GameLogic _gameLogic;
    private Component _root;

    public PressHandlerSubscriber(GameLogic gameLogic, Component root)
    {
        _gameLogic = gameLogic;
        _root = root;
    }
    
    public void SubscribePressHandlers()
    {
        Component board = _root.GetDirectChildOfType<BoardComponent>() ?? new Container();
        IEnumerable<BoxComponent> boxComponents = _root.GetChildComponentsOfType<BoxComponent>();
        
        foreach (BoxComponent boxComponent in boxComponents)
        {
            boxComponent.Pressed += (@event) =>
            {
                KeyNavigator.Navigate(@event, board);
                
                if (@event.KeyInfo.Key != ConsoleKey.Enter) return;
                _gameLogic.OnBoxPress(boxComponent.Box);
            };
        }
    }
}