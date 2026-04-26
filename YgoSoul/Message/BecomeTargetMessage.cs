using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class BecomeTargetMessage : BaseMessage
{
    public IReadOnlyList<FullLocationReference> Locations { get; set; }

    public BecomeTargetMessage(List<FullLocationReference> locations)
    {
        Locations = locations;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Targets on the following locations:");
        foreach (var l in Locations)
        {
            sb.AppendLine(l.ToString());
        }

        return sb.ToString();
    }
}