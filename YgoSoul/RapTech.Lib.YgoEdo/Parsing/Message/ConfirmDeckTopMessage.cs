using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ConfirmDeckTopMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<CardReference> Cards { get; }

    public ConfirmDeckTopMessage(byte player, List<CardReference> cards)
    {
        Player = player;
        Cards = cards;
    }

    public override string ToString()
    {
        return $"Confirm TopDeck - Player: {Player}, Cards: {string.Join(", ", Cards)}";
    }
}