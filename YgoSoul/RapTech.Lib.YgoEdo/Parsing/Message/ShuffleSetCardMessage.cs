using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ShuffleSetCardMessage : BaseMessage
{
    public OCG_CardLocation Location { get; }
    public IReadOnlyList<FullLocationReference> Cards { get; }
    public IReadOnlyList<FullLocationReference> Xyzs { get; }

    public ShuffleSetCardMessage(
        OCG_CardLocation location, 
        List<FullLocationReference> cards,
        List<FullLocationReference> xyzs
        )
    {
        Location = location;
        Cards = cards;
        Xyzs = xyzs;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("ShuffleSetCardMessage=[Cards=[");

        foreach (var c in Cards)
        {
            sb.AppendLine($"[{c}],");
        }

        sb.AppendLine("], XyzMaterials=[");
        
        
        foreach (var c in Cards)
        {
            
            sb.AppendLine($"[{c}],");
        }
        
        sb.AppendLine("]]");
        return sb.ToString();
    }
}