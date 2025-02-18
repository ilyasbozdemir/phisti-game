namespace PhistiCardGame.v1.Models;

public abstract class PlayCard
{
    public string Suit { get; set; }
    public string Value { get; set; }
    public string Emoji { get; set; }

    public PlayCard(string suit, string value)
    {
        Suit = suit;
        Value = value;
        Emoji = GetCardEmoji(suit);
    }

    private string GetCardEmoji(string suit)
    {
        return suit switch
        {
            "Kupa" => "\u2764", // ❤️
            "Karo" => "\u2666", // ♦️
            "Maca" => "\u2660", // ♠️
            "Sinek" => "\u2663", // ♣️
            _ => "❓"
        };
    }

    public override string ToString()
    {
        return $"{Suit}-{Value} {Emoji}";
    }
}
