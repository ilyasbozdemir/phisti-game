namespace PhistiCardGame.v1;

public class PhistiCard : PlayCard
{
    public int PointValue { get; set; }

    public PhistiCard(string suit, string value)
        : base(suit, value)
    {
        PointValue = PistiGameConfig.GetCardPointValue(value, suit);
    }
}
