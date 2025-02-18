using PhistiCardGame.v1.Services;

namespace PhistiCardGame.v1.Models;

public class PhistiCard : PlayCard
{
    public int PointValue { get; set; }

    public PhistiCard(string suit, string value)
        : base(suit, value)
    {
        PointValue = PhistiGameConfig.GetCardPointValue(value, suit);
    }
}
