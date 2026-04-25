using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class ConfirmCardsMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<CardReference> Cards { get; }

    public ConfirmCardsMessage(byte player, List<CardReference> cards)
    {
        Player = player;
        Cards = cards;
    }

    public override string ToString()
    {
        return $"Confirm Cards - Player: {Player}, Cards: {string.Join(", ", Cards)}";
    }
}