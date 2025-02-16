namespace PhistiCardGame.v1;

public class PistiGame
{
    public static List<PhistiCard> Deck = new List<PhistiCard>(); // Kart destesi
    public static List<PhistiCard> Floor = new List<PhistiCard>(); // Masadaki kartlar
    public static List<GamePlayer> Players = new List<GamePlayer>();
    public static GameMode CurrentGameMode { get; set; }
    public static int DealerIndex { get; set; } = 0;
    public static int CurrentRound { get; set; } = 1;

    private static Random random = new Random();



    public static void StartGame(GameMode gameMode)
    {
        CurrentGameMode = gameMode;
        CreateShuffleDeck();
        CreatePlayers();
        DealCards();
    }

    public static void CreateDeck()
    {
        string[] suits = { "Maca", "Kupa", "Karo", "Sinek" };
        string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "J", "Q", "K" };

        // Her suit ve her value için bir kart oluştur ve desteye ekle
        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                Deck.Add(new PhistiCard(suit, value));
            }
        }
    }

    public static void CreateShuffleDeck()
    {
        // Kartları oluştur
        CreateDeck();

        // Desteyi karıştır
        ShuffleDeck();
    }

    public static void CreatePlayers()
    {
        Players.Clear(); // Önceki oyuncuları temizle
        if (CurrentGameMode == GameMode.TwoPlayer)
        {
            Players.Add(new GamePlayer("Player", false, 1)); // Gerçek oyuncu
            Players.Add(new GamePlayer("Computer", true, 2)); // Bilgisayar
        }
        else if (CurrentGameMode == GameMode.FourPlayer)
        {
            Players.Add(new GamePlayer("Player", false, 1)); // Gerçek oyuncu
            Players.Add(new GamePlayer("Player 2", false, 2)); // Gerçek oyuncu
            Players.Add(new GamePlayer("Computer 1", true, 3)); // Bilgisayar
            Players.Add(new GamePlayer("Computer 2", true, 4)); // Bilgisayar
        }
    }

    public static void ShuffleDeck()
    {
        int n = Deck.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var value = Deck[k];
            Deck[k] = Deck[n];
            Deck[n] = value;
        }
    }

    public static void DealCards()
    {
        int cardsPerPlayer = 4;
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].Hand = Deck.Skip(i * cardsPerPlayer).Take(cardsPerPlayer).ToList();
        }
    }

    public static void AssignDealer()
    {
        // Dağıtan sırayla her round'da değişir
        Players[DealerIndex].IsDealer = true;
    }

    public static void NextRound()
    {
        // Round bitiminde sırayı güncelle
        CurrentRound++;
        DealerIndex = (DealerIndex + 1) % Players.Count; // Dağıtanı bir sonraki oyuncuya geçir
        foreach (var player in Players)
        {
            player.IsDealer = false; // Tüm oyunculardan dağıtanı kaldır
        }
        AssignDealer(); // Yeni dağıtanı belirle
    }
}
