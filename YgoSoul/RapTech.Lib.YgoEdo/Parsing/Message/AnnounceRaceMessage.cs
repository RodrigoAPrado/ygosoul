using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Card.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class AnnounceRaceMessage : BaseMessage, ISelectionOcgMessage, IAnnounceRaceMessage
{
    public override InputType Input => InputType.Selections;
    public override int InputCount => _races.Count;
    public byte Player { get; }
    public byte Count { get; }
    public IReadOnlyList<MonsterType> AvailableTypes { get; }
    public bool CanCancel => false;
    private readonly List<OCG_MonsterRaces> _races;
    
    public AnnounceRaceMessage(byte player, byte count, List<OCG_MonsterRaces> races)
    {
        Player = player;
        Count = count;
        _races = races;
        AvailableTypes= _races.Select(x => x.ToMonsterType()).ToList().AsReadOnly();
    }
    
    public override byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= _races.Count || x < 0);
        
        if (invalid)
            return [];

        if (ids.Count != Count)
            return [];

        ulong response = 0;

        foreach (var id in ids)
        {
            response |= (ulong) _races[id];
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
        sb.AppendLine($"[Player={Player}, Select={Count},");
        for (var i = 0; i< _races.Count; i++)
        {
            sb.AppendLine($"[{i}]=> Race_{i}={_races[i]}");
        }
        sb.AppendLine("]");
        return sb.ToString();
    }
}