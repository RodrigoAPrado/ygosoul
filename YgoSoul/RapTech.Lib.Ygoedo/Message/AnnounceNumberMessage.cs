using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class AnnounceNumberMessage : IMessage
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
    
    public byte[] GetResponse(int id)
    {
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