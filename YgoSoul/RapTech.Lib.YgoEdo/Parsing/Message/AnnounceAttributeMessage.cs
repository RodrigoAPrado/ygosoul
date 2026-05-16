using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Card.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class AnnounceAttributeMessage : BaseMessage, ISelectionOcgMessage, IAnnounceAttributeMessage
{
    public override InputType Input => InputType.Selections;
    public override int InputCount => Count;
    public byte Player { get; }
    public byte Count { get; }
    public IReadOnlyList<CardAttribute> Attributes 
        => _internalAttributes.Select(x => x.ToCardAttribute()).ToList();
    
    public bool CanCancel => false;
    private readonly List<OCG_MonsterAttributes> _internalAttributes;
    
    public AnnounceAttributeMessage(byte player, byte count, List<OCG_MonsterAttributes> attributes)
    {
        Player = player;
        Count = count;
        _internalAttributes = attributes;
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
        sb.AppendLine($"(AnnounceAttribute) [Player={Player}, Select {Count} Attributes:");
        for (var i = 0; i< Attributes.Count; i++)
        {
            sb.AppendLine($"[{i}] => {Attributes[i]}");
        }
        return sb.ToString();
    }
}