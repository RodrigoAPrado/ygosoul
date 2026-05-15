using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ConfirmExtraDeckTopMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<CardReference> Cards { get; }

    public ConfirmExtraDeckTopMessage(byte player, List<CardReference> cards)
    {
        Player = player;
        Cards = cards;
    }

    public override string ToString()
    {
        return $"Confirm ExtraTopDeck - Player: {Player}, Cards: {string.Join(", ", Cards)}";
    }
}