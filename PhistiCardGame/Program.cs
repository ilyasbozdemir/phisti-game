using PhistiCardGame.v1;

namespace PhistiCardGame;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Deste oluştur ve karıştır. Masa adı ile başlatılacak
        PhistiGame.StartGame(GameMode.FourPlayer, "Game Table 1");

        // Oluşturulan desteyi yazdır
        Console.WriteLine("Deste oluşturuldu ve karıştırıldı:");
        foreach (PhistiCard card in PhistiGame.Deck)
        {
            Console.Write($"{card.ToString(),-10}, "); 
        }

        Console.WriteLine("\n");
        Console.WriteLine("Yerdeki Taşlar :");
        Console.WriteLine("\n");


        foreach (PhistiCard floor in PhistiGame.Floor)
        {
            Console.WriteLine(floor.ToString());
        }

        // Masaları yazdır
        Console.WriteLine("\nMasalar:");
        foreach (var table in PhistiGame.GameTables)
        {
            Console.WriteLine($"Masa: {table.TableName}, ID: {table.Id}");
        }

        // Oyuncuları göster
        Console.WriteLine();
        Console.WriteLine("Oyuncular:");
        foreach (var player in PhistiGame.Players)
        {
            Console.WriteLine($"Oyuncu: {player.Name}, Sırası: {player.TurnOrder}");
        }
    }
}
