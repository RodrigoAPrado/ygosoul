using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class AnnounceRaceMessage : ISelectionsMessage
{
    public InputType Input => InputType.Selections;
    public int InputCount { get; }
    public byte Player { get; }
    public byte Count { get; }
    public List<MonsterRaces> Races { get; }
    public bool CanCancel => false;
    
    public AnnounceRaceMessage(byte player, byte count, List<MonsterRaces> races)
    {
        Player = player;
        Count = count;
        Races = races;
    }

    public byte[] GetResponse(int id)
    {
        return GetResponse([id]);
    }
    
    public byte[] GetResponse(List<int> ids)
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