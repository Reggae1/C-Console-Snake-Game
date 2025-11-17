using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Coordinates gridDimensions = new Coordinates(60, 20);
            Coordinates snakePosition = new Coordinates(30, 10);
            Random random = new Random();
            Coordinates foodPosition = new Coordinates(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
            int frameDelay = 100; // milliseconds
            Direction snakeMovement = Direction.Right;
            List<Coordinates> snakeBody = new List<Coordinates>();
            int score = 0;

            int snakeLength = 3;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Score: " + score);
                snakePosition.Applyovement(snakeMovement);
                for (int y = 0; y < gridDimensions.Y; y++)
                {
                    for (int x = 0; x < gridDimensions.X; x++)
                    {

                        Coordinates currentPosition = new Coordinates(x, y);
                        if (snakePosition.Equals(currentPosition) || snakeBody.Contains(currentPosition))
                        {
                            Console.Write("■");
                        }
                        else if (foodPosition.Equals(currentPosition))
                        {
                            Console.Write("a");
                        }
                        else if (x == 0 || x == gridDimensions.X - 1 || y == 0 || y == gridDimensions.Y - 1)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                if (snakePosition.Equals(foodPosition))
                {
                    snakeLength++;
                    score++;
                    foodPosition = new Coordinates(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
                }
                else if (snakePosition.X == 0 || snakePosition.X == gridDimensions.X - 1 || snakePosition.Y == 0 || snakePosition.Y == gridDimensions.Y - 1 || snakeBody.Contains(snakePosition))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! Final Score: " + score);
                    break;
                }

                snakeBody.Add(new Coordinates(snakePosition.X, snakePosition.Y));
                if (snakeBody.Count > snakeLength)
                {
                    snakeBody.RemoveAt(0);
                }
                DateTime time = DateTime.Now;
                while ((DateTime.Now - time).TotalMilliseconds < frameDelay)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey().Key;
                        switch (key)
                        {
                            case ConsoleKey.UpArrow:
                                if (snakeMovement != Direction.Down)
                                    snakeMovement = Direction.Up;
                                break;
                            case ConsoleKey.DownArrow:
                                if (snakeMovement != Direction.Up)
                                    snakeMovement = Direction.Down;
                                break;
                            case ConsoleKey.LeftArrow:
                                if (snakeMovement != Direction.Right)
                                    snakeMovement = Direction.Left;
                                break;
                            case ConsoleKey.RightArrow:
                                if (snakeMovement != Direction.Left)
                                    snakeMovement = Direction.Right;
                                break;
                        }
                    }
                }
            }
        }
    }
}