using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class RandomSelectedMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<FullLocationReference> Location { get; }

    public RandomSelectedMessage(byte player, IReadOnlyList<FullLocationReference> location)
    {
        Player = player;
        Location = location;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"RandomSelected=[\nPlayer={Player},Locations=[");

        foreach (var location in Location)
        {
            sb.AppendLine($"[{location}],");
        }
        
        sb.AppendLine("]]");
        return sb.ToString();
    }
}