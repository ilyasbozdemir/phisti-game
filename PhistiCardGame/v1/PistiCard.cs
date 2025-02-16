namespace PhistiCardGame.v1;

public class PistiCard
{
    public string Suit { get; set; }
    public string Value { get; set; }
    public string Emoji { get; set; }

    // Constructor to initialize suit, value and emoji
    public PistiCard(string suit, string value)
    {
        Suit = suit;
        Value = value;
        Emoji = GetCardEmoji(suit, value);
    }

    // Get the emoji representation for the card
    private string GetCardEmoji(string suit, string value)
    {
        // Emojis for suits
        string suitEmoji = suit switch
        {
            "Kupa" => "❤️",  // Kupa kartları için kalp emojisi
            "Karo" => "♦️",   // Karo kartları için karo simgesi
            "Maca" => "♠️",   // Maça kartları için siyah maça simgesi
            "Sinek" => "♣️",  // Sinek kartları için siyah sinek simgesi
            _ => "❓"
        };

        // Value-specific emoji
        string valueEmoji = value switch
        {
            "A" => "🅰️",    // As için emoji
            "2" => "2️⃣",
            "3" => "3️⃣",
            "4" => "4️⃣",
            "5" => "5️⃣",
            "6" => "6️⃣",
            "7" => "7️⃣",
            "8" => "8️⃣",
            "9" => "9️⃣",
            "10" => "🔟",
            "J" => "🃏",    // Jack için emoji
            "Q" => "👑",    // Queen için emoji
            "K" => "👑",    // King için emoji
            _ => "❓"
        };

        return $"{suitEmoji} {valueEmoji}";
    }

    // ToString method to display card as Suit-Value
    public override string ToString()
    {
        return $"{Suit}-{Value} ({Emoji})";
    }
}
