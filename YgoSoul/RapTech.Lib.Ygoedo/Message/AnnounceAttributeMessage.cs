using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class AnnounceAttributeMessage : ISelectionsMessage
{
    public InputType Input => InputType.Selections;
    public int InputCount { get; }
    public byte Player { get; }
    public byte Count { get; }
    public List<MonsterAttributes> Attributes { get; }
    public bool CanCancel => false;
    
    public AnnounceAttributeMessage(byte player, byte count, List<MonsterAttributes> attributes)
    {
        Player = player;
        Count = count;
        Attributes = attributes;
    }

    public byte[] GetResponse(int id)
    {
        return GetResponse([id]);
    }
    
    public byte[] GetResponse(List<int> ids)
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