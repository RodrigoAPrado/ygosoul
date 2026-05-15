using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class AnnounceAttributeMessage : BaseMessage, ISelectionsMessage
{
    public override InputType Input => InputType.Selections;
    public byte Player { get; }
    public byte Count { get; }
    public List<OCG_MonsterAttributes> Attributes { get; }
    public bool CanCancel => false;
    
    public AnnounceAttributeMessage(byte player, byte count, List<OCG_MonsterAttributes> attributes)
    {
        Player = player;
        Count = count;
        Attributes = attributes;
    }
    
    public override byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= Attributes.Count || x < 0);
        
        if (invalid)
            return [];

        if (ids.Count != Count)
            return [];

        uint response = 0;

        foreach (var id in ids)
        {
            response |= (uint) Attributes[id];
        }

        return BitConverter.GetBytes(response);
    }

    public byte[] Cancel()
    {
        return [];
    }
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"AnnounceAttribute, \nPlayer={Player}, Select {Count} Races:");
        for (var i = 0; i< Attributes.Count; i++)
        {
            sb.AppendLine($"[{i}] => {Attributes[i]}");
        }
        return sb.ToString();
    }
}