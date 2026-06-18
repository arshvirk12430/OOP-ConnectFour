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
        public bool CheckWin(char symbol)
{
    //  Checking for horizontal winner
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 4; c++)
        {
            if (grid[r, c] == symbol &&
                grid[r, c + 1] == symbol &&
                grid[r, c + 2] == symbol &&
                grid[r, c + 3] == symbol)
            {
                return true;
            }
        }
    }

    // vertical winner
    for (int c = 0; c < 7; c++)
    {
        for (int r = 0; r < 3; r++)
        {
            if (grid[r, c] == symbol &&
                grid[r + 1, c] == symbol &&
                grid[r + 2, c] == symbol &&
                grid[r + 3, c] == symbol)
            {
                return true;
            }
        }
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

     while (true)

     {

         Console.Write("Choose column (1-7): ");


         string input = Console.ReadLine();


         int move;


         if (int.TryParse(input, out move))

         {

             return move - 1;

         }


         Console.WriteLine("Please enter a number.");

     }

 }
    }


    class Gamemanager
    {
        Board board = new Board();
        Player p1;
        Player p2;
        Player current;

        public void Start()
        {
            p1 = new HumanPlayer("Player 1", 'X');
            p2 = new HumanPlayer("Player 2", 'O');
            current = p1;

            while (true)
            {
                board.PrintBoard();

                int move = current.GetMove();

                if (move < 0 || move > 6 || board.IsColumnFull(move))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                board.DropPiece(move, current.Symbol);

                if (CheckWin(current.Symbol))
                {
                    board.PrintBoard();
                    Console.WriteLine(current.Name + " wins!");
                    break;
                }

                SwitchPlayer();
            }
        }

        void SwitchPlayer()
        {
            current = (current == p1) ? p2 : p1;
        }

        bool CheckWin(char symbol)
        {
            // (simplified check - you can expand later)
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           Gamemanager game = new Gamemanager();
        game.Start();
        }
    }
}
