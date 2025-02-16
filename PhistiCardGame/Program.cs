using PhistiCardGame.v1;

namespace PhistiCardGame;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        PistiGame.StartGame(GameMode.TwoPlayer);

       
    }
}
