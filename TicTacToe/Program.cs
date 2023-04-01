namespace TicTacToe;

public sealed class TicTacToe
{
    internal static GameLoop GameLoop;

    static TicTacToe()
    {
        GameLoop = new GameLoop(null, null);
    }
    
    public static void Main(string[] args)
    {
        Board board = new(3);
        BoardView boardView = new(board);
        boardView.RenderAndDelegateToChildren();
    }
}

abstract class View : IRenderable, IClickable
{
    private readonly List<View> _children = new();
    public IEnumerable<View> Children => _children;
    public Position Position { get; set; }
    public Dimension Dimension { get; set; }
    
    public abstract void OnKeyPress(ConsoleKeyInfo keyInfo, Position position);
    
    public abstract void Render();

    public void RenderAndDelegateToChildren()
    {
        Render();
        foreach (View child in _children)
        {
            child.RenderAndDelegateToChildren();
        }
    }
    
    public void AddChild(View view)
    {
        _children.Add(view);
    }

    public void RemoveChild(View view)
    {
        _children.Remove(view);
    }
}

abstract class View<T> : View, IObservable<T>
{
    private readonly List<IObserver<T>> _observers = new();
    public T Model { get; }
    public Position Position { get; set; }
    public Dimension Dimension { get; set; }

    protected View(T model)
    {
        Model = model;
    }
    
    public override void OnKeyPress(ConsoleKeyInfo keyInfo, Position position)
    {
        foreach (var observer in _observers)
        {
            observer.HandleKeyPress(Model, keyInfo);
        }
    }
    
    public abstract override void Render();

    public void Subscribe(IObserver<T> observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IObserver<T> observer)
    {
        _observers.Remove(observer);
    }
}

interface IObservable<T>
{
    void Subscribe(IObserver<T> observer);

    void Unsubscribe(IObserver<T> observer);
}

interface IObserver<T>
{
    void HandleKeyPress(T observable, ConsoleKeyInfo keyInfo);
}

interface IRenderable
{
    void Render();

    void RenderAndDelegateToChildren();
}

interface IClickable
{
    void OnKeyPress(ConsoleKeyInfo keyInfo, Position position);
}

struct Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

struct Dimension
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Dimension(int width, int height)
    {
        Width = width;
        Height = height;
    }
}

class GameLoop
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

class InputHandler
{
    private readonly View _primaryView;

    public InputHandler(View primaryView)
    {
        _primaryView = primaryView;
    }
    
    public void ReceiveAndHandleInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Position position = new(Console.CursorLeft, Console.CursorTop);
        _primaryView.OnKeyPress(keyInfo, position);
    }
}

class GameRenderer
{
    private readonly View _primaryView;

    public GameRenderer(View primaryView)
    {
        _primaryView = primaryView;
    }
        
    public void Init()
    {
        throw new NotImplementedException();
    }
    
    public void Render()
    {
        _primaryView.RenderAndDelegateToChildren();
    }
}

class Board
{
    private readonly Box[] _boxes;
    public int Size { get; }
    public int Area => Size * Size;

    public Board(int size)
    {
        Size = size;
        _boxes = GenerateBoxes();
    }

    private Box[] GenerateBoxes()
    {
        var boxes = new Box[Area];
        for (int i = 0; i < Area; i++)
        {
            boxes[i] = new Box();
        }

        return boxes;
    }

    public Box GetBoxByIndex(int index)
    {
        return _boxes[index];
    }
}

class Box
{
    public const char Empty = ' ';
    public char Piece { get; set; } = Empty;
}

class BoxView : View<Box>
{
    public BoxView(Box model) : base(model) { }

    public override void Render()
    {
        Console.WriteLine("Rendering a box.");
    }
}

class BoardView : View<Board>
{
    public BoardView(Board model) : base(model)
    {
        for (int i = 0; i < model.Area; i++)
        {
            AddChild(new BoxView(model.GetBoxByIndex(i)));
        }
    }

    public override void Render()
    {
        Console.WriteLine("Rendering a board.");
    }
}

class Game
{
    private readonly Player[] _players;
    public Statistics Statistics { get; }
    public Player CurrentPlayer { get; private set; }
    public GameState GameState { get; set; }

    public Game(Player[] players, Player startingPlayer)
    {
        _players = players;
        Statistics = new Statistics(players);
        CurrentPlayer = startingPlayer;
    }
    
    public void Start()
    {
        GameState = GameState.Intermediate;
    }
    
    public void Stop()
    {
        GameState = GameState.Stopped;
    }

    public void SwitchPlayer()
    {
        int currentPlayerIndex = GetCurrentPlayerIndex();
        
        if (currentPlayerIndex + 1 == _players.Length)
        {
            currentPlayerIndex = 0;
        }
        else
        {
            currentPlayerIndex++;
        }

        CurrentPlayer = _players[currentPlayerIndex];
    }

    private int GetCurrentPlayerIndex()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] == CurrentPlayer) return i;
        }

        throw new KeyNotFoundException();
    }
}

class Player
{
    public string Name { get; set; }
    public char Piece { get; set; }
}

class Statistics
{
    private readonly Dictionary<Player, int> _playerStatistics = new();
    public int Ties { get; private set; }

    public Statistics(Player[] players)
    {
        foreach (Player player in players)
        {
            _playerStatistics.Add(player, 0);
        }
    }
    
    public void IncreaseWinsFor(Player player)
    {
        _playerStatistics.TryGetValue(player, out int currentScore);
        
        currentScore += 1;
        
        if (_playerStatistics.ContainsKey(player))
        {
            _playerStatistics[player] = currentScore;
        }
        else
        {
            _playerStatistics.Add(player, currentScore);
        }
    }

    public void IncreaseTies()
    {
        Ties++;
    }
}

class PiecePlacer : IObserver<BoxView>
{
    private Game _game;
    
    public void HandleKeyPress(BoxView boxView, ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key != ConsoleKey.Enter) return;
        if (_game.GameState == GameState.Stopped) return;
        boxView.Model.Piece = _game.CurrentPlayer.Piece;
    }
}

class Dash
{
    public int Length { get; }
    public DashInfo DashInfo { get; set; }
}

class GameController : IObserver<BoardView>
{
    private Game _game;
    private BoardEvaluator _boardEvaluator;
    private Dash _dash;
    
    public void HandleKeyPress(BoardView boardView, ConsoleKeyInfo keyInfo)
    {
        Evaluation evaluation = _boardEvaluator.EvaluateAndGenerateDashInfo(boardView.Model);
        HandleGameState(evaluation.GameState, evaluation.DashInfo); // Smells bad.
    }

    private void HandleGameState(GameState gameState, DashInfo? dashInfo)
    {
        switch (gameState)
        {
            case GameState.Win:
                if (dashInfo == null) throw new ArgumentException("");
                _game.Statistics.IncreaseWinsFor(_game.CurrentPlayer);
                _game.Stop();
                _dash.DashInfo = dashInfo;
                break;
            case GameState.Tie:
                _game.Statistics.IncreaseTies();
                _game.Stop();
                break;
            case GameState.Intermediate:
                _game.SwitchPlayer();
                break;
            default:
                throw new ArgumentException("");
        }
    }
}

class BoardEvaluator
{
    public Evaluation EvaluateAndGenerateDashInfo(Board board)
    {
        throw new NotImplementedException();
    }
}

class Evaluation
{
    public GameState GameState { get; }
    public DashInfo? DashInfo { get; }

    public Evaluation(GameState gameState, DashInfo? dashInfo = null)
    {
        GameState = gameState;
        DashInfo = dashInfo;
    }
}

class DashInfo
{
    private Orientation _orientation;
    private Position[] _positions;
}

enum Orientation
{
    Horizontal,
    Vertical,
    PrimaryDiagonal,
    SecondaryDiagonal
}

enum GameState
{
    Win,
    Tie,
    Intermediate,
    Stopped
}