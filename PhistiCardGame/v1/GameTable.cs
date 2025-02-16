namespace PhistiCardGame.v1;

public class GameTable
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string TableName { get; set; } = "Table 1"; // Masa adı
    public List<GamePlayer> TeamOne { get; set; } = new List<GamePlayer>();
    public List<GamePlayer> TeamTwo { get; set; } = new List<GamePlayer>();

    public void DisplayTeams()
    {
        Console.WriteLine($"Table: {TableName} (ID: {Id})");

        Console.WriteLine("Team One:");
        foreach (var player in TeamOne)
        {
            Console.WriteLine($"Name: {player.Name}, Team: 1");
        }

        Console.WriteLine("Team Two:");
        foreach (var player in TeamTwo)
        {
            Console.WriteLine($"Name: {player.Name}, Team: 2");
        }
    }
}
