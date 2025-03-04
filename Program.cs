using System;
using System.Numerics;

internal class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Run();
    }
}
internal class Game
{
    private int width;
    private int height;
    private int foodX;
    private int foodY;
    private Player player;

    public void Run()
    {
        Initialize();
        Console.WriteLine("Game started...");
        player.Draw();
        PlaceAndDrawFood();

        while (true)
        {
            HandleInput();
            player.Draw();
            System.Threading.Thread.Sleep(100); // Delay to slow down the loop
        }
    }

    private void Initialize()
    {
        Console.CursorVisible = false;
        width = Console.WindowWidth - 5;
        height = Console.WindowHeight - 1;
        player = new Player(width / 2, height / 2);
        foodX = 0;
        foodY = 0;
    }

    private void PlaceAndDrawFood()
    {
        Random random = new Random();
        foodX = random.Next(0, width);
        foodY = random.Next(0, height);
        Console.SetCursorPosition(foodX, foodY);
        Console.Write('O'); // Symbol representing the food
    }

    private void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(intercept: true).Key;
            player.Move(key, width, height);
        }
    }
}


internal class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Player(int startX, int startY)
    {
        X = startX;
        Y = startY;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write('@'); // Symbol representing the player
    }

    public void Move(ConsoleKey key, int width, int height)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                Y = Math.Max(0, Y - 1);
                break;
            case ConsoleKey.DownArrow:
                Y = Math.Min(height, Y + 1);
                break;
            case ConsoleKey.LeftArrow:
                X = Math.Max(0, X - 1);
                break;
            case ConsoleKey.RightArrow:
                X = Math.Min(width, X + 1);
                break;
        }
    }
}

internal class Food
{

}