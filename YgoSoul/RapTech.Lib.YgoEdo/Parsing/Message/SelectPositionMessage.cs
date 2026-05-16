using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SelectPositionMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => PositionAvailable.Count;

    public byte Player { get; }
    public uint CardCode { get; }
    public IReadOnlyList<OCG_CardPosition> PositionAvailable { get; }

    public SelectPositionMessage(byte player, uint cardCode, List<OCG_CardPosition> positionAvailable)
    {
        Player = player;
        CardCode = cardCode;
        PositionAvailable = positionAvailable;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];
        
        if (id < 0 || id >= PositionAvailable.Count)
            return [];
        var position = (uint) PositionAvailable[id];
        return BitConverter.GetBytes(position);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player} select a position for card {CardLibrary.InternalGetCard(CardCode).Name}:");
        for (var i = 0; i < PositionAvailable.Count; i++)
        {
            sb.AppendLine($"[{i}] => {PositionAvailable[i]}");
        }

        return sb.ToString();
    }
}