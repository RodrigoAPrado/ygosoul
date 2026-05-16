using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

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