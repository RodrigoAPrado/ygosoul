using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class AnnounceRaceMessage : IMessage
{
    public InputType Input { get; }
    public int InputCount { get; }
    public byte Player { get; }
    public byte Count { get; }
    public List<MonsterRaces> Races { get; }
    
    public AnnounceRaceMessage(byte player, byte count, List<MonsterRaces> races)
    {
        Player = player;
        Count = count;
        Races = races;
    }

    public byte[] GetResponse(int id)
    {
        throw new NotImplementedException();
    }
    
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"AnnounceRace, \nPlayer={Player}, Select {Count} Races:");
        for (var i = 0; i< Races.Count; i++)
        {
            sb.AppendLine($"[{i}] => {Races[i]}");
        }
        sb.AppendLine("Select with using \",\" like so. Ex: 0,5,8...");
        return sb.ToString();
    }
}