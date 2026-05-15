using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class AnnounceRaceMessage : BaseMessage, ISelectionsMessage
{
    public override InputType Input => InputType.Selections;
    public override int InputCount => Races.Count;
    public byte Player { get; }
    public byte Count { get; }
    public List<OCG_MonsterRaces> Races { get; }
    public bool CanCancel => false;
    
    public AnnounceRaceMessage(byte player, byte count, List<OCG_MonsterRaces> races)
    {
        Player = player;
        Count = count;
        Races = races;
    }
    
    public override byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= Races.Count || x < 0);
        
        if (invalid)
            return [];

        if (ids.Count != Count)
            return [];

        ulong response = 0;

        foreach (var id in ids)
        {
            response |= (ulong) Races[id];
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
        sb.AppendLine($"AnnounceRace, \nPlayer={Player}, Select {Count} Races:");
        for (var i = 0; i< Races.Count; i++)
        {
            sb.AppendLine($"[{i}] => {Races[i]}");
        }
        return sb.ToString();
    }
}