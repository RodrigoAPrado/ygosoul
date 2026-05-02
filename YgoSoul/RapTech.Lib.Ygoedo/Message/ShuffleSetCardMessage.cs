using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class ShuffleSetCardMessage : BaseMessage
{
    public CardLocation Location { get; }
    public IReadOnlyList<FullLocationReference> Cards { get; }
    public IReadOnlyList<FullLocationReference> Xyzs { get; }

    public ShuffleSetCardMessage(
        CardLocation location, 
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