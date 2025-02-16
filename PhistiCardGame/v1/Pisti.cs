namespace PhistiCardGame.v1;

public class Pisti
{
    private static List<PistiCard> Deck = new List<PistiCard>(); // Kart destesi
    private static List<PistiCard> Floor = new List<PistiCard>(); // Masadaki kartlar
    private static List<PistiCard> PlayerHand = new List<PistiCard>(); // Oyuncunun eli
    private static List<PistiCard> ComputerHand = new List<PistiCard>(); // Bilgisayarın eli

    private static Random random = new Random();

    public static void CreateDeck()
    {
        string[] suits = { "Maca", "Kupa", "Karo", "Sinek" };
        string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "K", "Q", "J" };


    }


}
