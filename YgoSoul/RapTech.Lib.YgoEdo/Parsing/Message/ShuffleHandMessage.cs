using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class ShuffleHandMessage : BaseMessage
{
    public byte Player { get; }
    public List<uint> Cards { get; }

    public ShuffleHandMessage(byte player, List<uint> cards)
    {
        Player = player;
        Cards = cards;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"New card order in hand for player {Player}: ");
        foreach (var c in Cards)
        {
            sb.Append($"{CardLibrary.InternalGetCard(c).Name}, ");
        }
        return sb.ToString().TrimEnd(',');
    }
}