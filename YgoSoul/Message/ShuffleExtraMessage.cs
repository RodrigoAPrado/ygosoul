using System.Text;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class ShuffleExtraMessage : BaseMessage
{
    public byte Player { get; }
    public List<uint> Cards { get; }

    public ShuffleExtraMessage(byte player, List<uint> cards)
    {
        Player = player;
        Cards = cards;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"New card order in extra for player {Player}: ");
        foreach (var c in Cards)
        {
            sb.Append($"{CardLibrary.GetCard(c).Name}, ");
        }
        return sb.ToString().TrimEnd(',');
    }
}