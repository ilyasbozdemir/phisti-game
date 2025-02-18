namespace PhistiCardGame.v1;

public class PhistiGameManager
{
    private static int no = 1;
    private static List<GameTeam> teams = new List<GameTeam>();
    private static List<GamePlayer> players = new List<GamePlayer>();
    private static Dictionary<Guid, GameSession> sessions = new Dictionary<Guid, GameSession>();

    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Pişti Oyununa Hoş Geldiniz!");
            Console.WriteLine("1. Oturum Aç");
            Console.WriteLine("2. Yeni Oyun Başlat");
            Console.WriteLine("3. Mevcut Masaya Katıl");
            Console.WriteLine("4. Oyuncu Profillerini Görüntüle");
            Console.WriteLine("5. Liderlik Tablosunu Görüntüle");
            Console.WriteLine("6. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateSession();
                    break;
                case "2":
                    StartNewGame();
                    break;
                case "3":
                    JoinExistingTable();
                    break;
                case "4":
                    DisplayPlayerProfiles();
                    break;
                case "5":
                    DisplayLeaderboard();
                    break;
                case "6":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    private static void CreateSession()
    {
        Console.Write("Lütfen oyuncu adınızı girin: ");
        var playerName = Console.ReadLine();
        var player = new GamePlayer(playerName, false);
        players.Add(player);

        var session = new GameSession(player);
        sessions.Add(player.Id, session);

        Console.WriteLine($"Oturum oluşturuldu: {playerName}");
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey();
    }

    private static void StartNewGame()
    {
        Console.Write("Lütfen oturum ID'sini girin: ");
        var sessionIdInput = Console.ReadLine();
        if (Guid.TryParse(sessionIdInput, out Guid sessionId) && sessions.ContainsKey(sessionId))
        {
            var session = sessions[sessionId];
            Console.Write("Lütfen masa adını girin: ");
            var tableName = Console.ReadLine();

            var newTable = PhistiGame.CreateGameTable(tableName);
            newTable.No = no;
            no++; // Masa numarasını artır

            // Takım oluşturma
            Console.Write("Birinci takımın adını girin: ");
            var team1Name = Console.ReadLine();
            var team1 = new GameTeam(team1Name);
            teams.Add(team1);

            Console.Write("İkinci takımın adını girin: ");
            var team2Name = Console.ReadLine();
            var team2 = new GameTeam(team2Name);
            teams.Add(team2);

            // Oyuncuları takımlara ekleme
            AddPlayersToTeam(team1);
            AddPlayersToTeam(team2);

            PhistiGame.StartGame(GameMode.FourPlayer, newTable);

            Console.WriteLine($"Yeni oyun başlatıldı: {tableName}, Masa No: {newTable.No}");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Geçersiz oturum ID'si.");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    private static void AddPlayersToTeam(GameTeam team)
    {
        foreach (var player in players.Where(p => p.TeamId == Guid.Empty))
        {
            Console.Write($"Takım {team.Name} için oyuncu {player.Name} katılmak ister misiniz? (E/H): ");
            var response = Console.ReadLine();
            if (response?.ToLower() == "e")
            {
                player.TeamId = team.Id;
                team.Players.Add(player);
                if (team.Players.Count == 2)
                    break;
            }
        }
    }

    private static void JoinExistingTable()
    {
        Console.WriteLine("Mevcut masalar:");
        foreach (var table in PhistiGame.GameTables)
        {
            Console.WriteLine($"Masa: {table.TableName}, Id: {table.Id}, No: {table.No}");
        }

        Console.Write("Katılmak istediğiniz masanın No'sunu girin: ");
        var tableNoInput = Console.ReadLine();
        if (int.TryParse(tableNoInput, out int tableNo))
        {
            var selectedTable = PhistiGame.GameTables.FirstOrDefault(t => t.No == tableNo);
            if (selectedTable != null)
            {
                Console.Write("Lütfen oturum ID'sini girin: ");
                var sessionIdInput = Console.ReadLine();
                if (Guid.TryParse(sessionIdInput, out Guid sessionId) && sessions.ContainsKey(sessionId))
                {
                    var session = sessions[sessionId];
                    var player = session.Player;

                    // Oyuncuyu seçilen masaya ekleyin (bu kısım oyunun mantığına göre düzenlenmelidir)
                    // selectedTable.AddPlayer(player);

                    Console.WriteLine($"Masa: {selectedTable.TableName} oyununa katılıyorsunuz...");
                }
                else
                {
                    Console.WriteLine("Geçersiz oturum ID'si.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz masa No'su.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz formatta No girdiniz.");
        }

        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey();
    }

    private static void DisplayPlayerProfiles()
    {
        Console.WriteLine("Oyuncu Profilleri:");
        foreach (var player in players)
        {
            Console.WriteLine($"Oyuncu: {player.Name}, Skor: {player.Score}");
        }

        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey();
    }

    private static void DisplayLeaderboard()
    {
        Console.WriteLine("Liderlik Tablosu:");
        var topPlayers = players.OrderByDescending(p => p.Score).Take(10);
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Oyuncu: {player.Name}, Skor: {player.Score}");
        }

        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey();
    }
}

public class GameSession
{
    public GamePlayer Player { get; private set; }

    public GameSession(GamePlayer player)
    {
        Player = player;
    }
}