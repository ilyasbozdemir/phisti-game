using PhistiCardGame.v1;

namespace PhistiCardGame;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Deste oluştur ve karıştır.
        PistiGame.StartGame(GameMode.TwoPlayer);

        // Oluşturulan desteyi yazdır
        Console.WriteLine("Deste oluşturuldu ve karıştırıldı:");
        foreach (var card in PistiGame.Deck)
        {
            Console.WriteLine(card.ToString());
        }
    }
}
