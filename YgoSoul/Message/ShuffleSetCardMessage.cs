using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

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