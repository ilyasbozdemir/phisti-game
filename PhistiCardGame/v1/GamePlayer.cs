namespace PhistiCardGame.v1;

public class GamePlayer
{
    public string Name { get; set; } // Oyuncunun adı
    public bool IsComputer { get; set; } // Bilgisayar mı, gerçek oyuncu mu
    public List<PhistiCard> Hand { get; set; } // Oyuncunun eli
    public int TurnOrder { get; set; } // Oyuncunun sırası (Turn sırası)
    public bool IsDealer { get; set; } // Dağıtan oyuncu mu
    public GamePlayer(string name, bool isComputer, int turnOrder = 0, bool isDealer = false)
    {
        Name = name;
        IsComputer = isComputer;
        Hand = new List<PhistiCard>();
        TurnOrder = turnOrder;
        IsDealer = isDealer;
    }
}
