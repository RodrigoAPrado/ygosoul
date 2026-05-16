using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class AnnounceNumberMessage : BaseMessage, ISelectionOcgMessage, IAnnounceNumberMessage
{
    public override InputType Input => InputType.Value;
    public override int InputCount => 1;
    public byte Player { get; }
    public IReadOnlyList<uint> AvailableNumbers { get; }

    public AnnounceNumberMessage(byte player, List<uint> availableNumbers)
    {
        Player = player;
        AvailableNumbers = availableNumbers;
    }
    
    public override byte[] GetResponse(List<int> input)
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

    public bool CanCancel => false;
    public byte[] Cancel()
    {
        return [];
    }
}