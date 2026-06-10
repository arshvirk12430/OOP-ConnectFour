namespace OOP_ConnectFour
{

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
