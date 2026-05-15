using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

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