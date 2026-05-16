using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class BecomeTargetMessage : BaseMessage, IBecomeTargetMessage
{
    public IReadOnlyList<IFullLocationReference> Locations => _locations;
    
    private readonly List<FullLocationReference> _locations;

    public BecomeTargetMessage(List<FullLocationReference> locations)
    {
        _locations = locations;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("[");

        for (var i = 0; i < _locations.Count; i++)
        {
            sb.AppendLine($"Target_{i}={_locations[i]}");
        }

        sb.AppendLine("]");
        return sb.ToString();
    }
}