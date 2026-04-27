using System.Text;
using YgoSoul.DuelRunner;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

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
            sb.Append($"{CardLibrary.GetCard(c).Name}, ");
        }
        return sb.ToString().TrimEnd(',');
    }
}