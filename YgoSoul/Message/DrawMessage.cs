using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class DrawMessage : BaseMessage
{
    public uint Player { get; }
    public List<DrawnCard> Cards { get; }
    public DrawMessage(uint player, List<DrawnCard> cards)
    {
        Player = player;
        Cards = cards;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player} drew the following cards:");
        foreach (var card in Cards)
        {
            sb.AppendLine($"- {card.ToString()}");
        }

        return sb.ToString();
    }
}