namespace PhistiCardGame.v1;

public class PistiGameConfig
{
    // Kart puanları için Dictionary
    public static Dictionary<(string value, string suit), int> CardPointValues { get; set; }

    // Özel Kartlar ve diğer kurallar
    public static int PistiPoint { get; set; } = 10; // Normal Pisti
    public static int JacksPistiPoint { get; set; } = 10; // J kartı için Pisti
    public static List<int> SupportedScores { get; set; } =
        new List<int> { 51, 101, 151, 201, 251 }; // Desteklenen skorlar

    // Round sayısı ayarı (1-5 arası, istenilen şekilde)
    public static int MaxRounds { get; set; } = 5; // Round sayısı 1 ile 5 arasında belirlenebilir

    // Sabit kart fazlası puanı
    public const int ExtraCardPoint = 3; // Kart fazlası puanı 3 olarak sabitlendi.

    static PistiGameConfig() // Static Constructor
    {
        // Kart puanlarını başlat
        CardPointValues = new Dictionary<(string, string), int>
        {
            { ("A", "Kupa"), 1 }, // As -> 1 puan (her suit'te geçerli)
            { ("A", "Maca"), 1 },
            { ("A", "Karo"), 1 },
            { ("A", "Sinek"), 1 },
            { ("J", "Kupa"), 1 }, // Vale (J) -> 1 puan (her suit'te geçerli)
            { ("J", "Maca"), 1 },
            { ("J", "Karo"), 1 },
            { ("J", "Sinek"), 1 },
            { ("10", "Karo"), 3 }, // Karo 10 -> 3 puan
            { ("2", "Sinek"), 2 }, // Sinek 2 -> 2 puan
        };
    }

    // Kartın puan değerini almak için metod
    public static int GetCardPointValue(string value, string suit)
    {
        if (CardPointValues.TryGetValue((value, suit), out int pointValue))
        {
            return pointValue;
        }
        return 0; // Eğer kartın puan değeri yoksa
    }
}
