using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class RemoveCardsMessage : BaseMessage
{
    public IReadOnlyList<FullLocationReference> Locations { get; }

    public RemoveCardsMessage(List<FullLocationReference> locations)
    {
        Locations = locations;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"RemoveCards=[");
        foreach (var l in Locations)
        {
            sb.AppendLine($"{l},");
        }
        sb.AppendLine("]");
        return sb.ToString();
    }
}