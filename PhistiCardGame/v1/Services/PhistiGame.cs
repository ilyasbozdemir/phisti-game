using PhistiCardGame.v1.Models;

namespace PhistiCardGame.v1.Services;

public class PhistiGame
{
    public static List<PhistiCard> Deck = new List<PhistiCard>(); // Kart destesi
    public static List<PhistiCard> Floor = new List<PhistiCard>(); // Masadaki kartlar
    public static List<GameTable> GameTables = new List<GameTable>();
    public static List<GamePlayer> Players = new List<GamePlayer>();

    public static GameMode CurrentGameMode { get; set; }
    public static int DealerIndex { get; set; } = 0;
    public static int CurrentRound { get; set; } = 1;

    private static Random random = new Random();

    public static void StartGame(GameMode gameMode, GameTable gameTable)
    {
        CurrentGameMode = gameMode;

        GameTables.Add(gameTable);

        CreateShuffleDeck();
        CreatePlayers(gameTable.Id);
        SplitAndCombineDeck();
        DealCards();
    }

    static int tableNo = 0;

    public static GameTable CreateGameTable(string tableName)
    {
        tableNo++;
        var newTable = new GameTable { TableName = tableName, No = tableNo };
        newTable.No = tableNo;

        return newTable;
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

    public static void CreatePlayers(Guid tableID)
    {
        Players.Clear(); // Önceki oyuncuları temizle
        var selectedTable = GameTables.FirstOrDefault(table => table.Id == tableID);

        if (selectedTable != null)
        {
            if (CurrentGameMode == GameMode.TwoPlayer)
            {
                Players.Add(new GamePlayer("Player", false, 1)); // Gerçek oyuncu
                Players.Add(new GamePlayer("Computer", true, 2)); // Bilgisayar

                selectedTable.TeamOne.Add(Players[0]); // Player
                selectedTable.TeamOne.Add(Players[1]); // Computer 1
            }
            else if (CurrentGameMode == GameMode.FourPlayer)
            {
                Players.Add(new GamePlayer("Player", false, 1)); // Gerçek oyuncu
                Players.Add(new GamePlayer("Computer 1", true, 2)); // Bilgisayar
                Players.Add(new GamePlayer("Computer 2", true, 3)); // Bilgisayar
                Players.Add(new GamePlayer("Computer 3", true, 4)); // Bilgisayar

                selectedTable.TeamOne.Add(Players[0]); // Player
                selectedTable.TeamOne.Add(Players[1]); // Computer 1

                selectedTable.TeamTwo.Add(Players[2]); // Computer 2
                selectedTable.TeamTwo.Add(Players[3]); // Computer 3
            }
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

    public static List<PhistiCard> SplitAndCombineDeck()
    {
        // su anlık ikiye ayıtmak için oldu bu


        // Deck'i ikiye böl
        int mid = Deck.Count / 2;
        var firstHalf = Deck.Take(mid).ToList();
        var secondHalf = Deck.Skip(mid).ToList();

        // İkinci parçayı ilk parçanın önüne yerleştir
        var combinedDeck = secondHalf.Concat(firstHalf).ToList();

        // 4 kartı yere aç ve yeni deste olarak döndür
        var openedCards = combinedDeck.Take(4).ToList();
        Floor.AddRange(openedCards);
        var remainingDeck = combinedDeck.Skip(4).ToList();

        return remainingDeck;
    }

    public static void DealCards() { }

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
