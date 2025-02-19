﻿namespace PhistiCardGame.v1.Models;

public class GamePlayer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TeamId { get; set; } = Guid.NewGuid();


    public string Name { get; set; } // Oyuncunun adı
    public bool IsComputer { get; set; } // Bilgisayar mı, gerçek oyuncu mu
    public List<PlayCard> Hand { get; set; } // Oyuncunun eli
    public int TurnOrder { get; set; } // Oyuncunun sırası (Turn sırası)
    public bool IsDealer { get; set; } // Dağıtan oyuncu mu
    public int Score { get; set; } // Oyuncunun skoru

    public GamePlayer(string name, bool isComputer, int turnOrder = 0, bool isDealer = false)
    {
        Name = name;
        IsComputer = isComputer;
        Hand = new List<PlayCard>();
        TurnOrder = turnOrder;
        IsDealer = isDealer;
        Score = 0;
    }
}
