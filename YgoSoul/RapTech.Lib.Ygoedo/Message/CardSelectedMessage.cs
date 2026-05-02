using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class CardSelectedMessage : BaseMessage
{
    public IReadOnlyList<FullLocationReference> Locations { get; set; }

    public CardSelectedMessage(List<FullLocationReference> locations)
    {
        Locations = locations;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Cards selected on the following locations:");
        foreach (var l in Locations)
        {
            sb.AppendLine(l.ToString());
        }

        return sb.ToString();
    }
}