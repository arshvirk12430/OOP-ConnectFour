namespace OOP_ConnectFour
{


    using System;

    class Board
    {
        private char[,] grid = new char[6, 7];

        public Board()
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    grid[r, c] = '.';
        }

        public void PrintBoard()
        {
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    Console.Write(grid[r, c] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7");
        }

        public bool DropPiece(int col, char symbol)
        {
            for (int r = 5; r >= 0; r--)
            {
                if (grid[r, col] == '.')
                {
                    grid[r, col] = symbol;
                    return true;
                }
            }
            return false; // column full
        }

        public bool IsColumnFull(int col)
        {
            return grid[0, col] != '.';
        }
    }


    public abstract class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public abstract int GetMove();
    }
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol): base(name, symbol)
        {

        }
         
        public override int GetMove()
        {
            Console.Write("Choose column (1-7): ");
            return int.Parse(Console.ReadLine());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
