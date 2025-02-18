namespace PhistiCardGame.v1.Models;

public class GameTeam
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } // Takım adı
    public List<GamePlayer> Players { get; set; } = new List<GamePlayer>();

    public GameTeam(string name)
    {
        Name = name;
    }
}