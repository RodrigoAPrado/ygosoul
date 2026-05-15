using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class AnnounceNumberMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => AvailableNumbers.Count;

    public byte Player { get; }
    public IReadOnlyList<uint> AvailableNumbers { get; }

    public AnnounceNumberMessage(byte player, List<uint> availableNumbers)
    {
        Player = player;
        AvailableNumbers = availableNumbers;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];
        
        if (id < 0 || id >= AvailableNumbers.Count)
            return [];
        
        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player={Player}, choose a number below:");
        for (var i = 0; i < AvailableNumbers.Count; i++)
        {
            sb.AppendLine($"[{i}]=> Declare {AvailableNumbers[i]}");
        }
        return sb.ToString();
    }
}