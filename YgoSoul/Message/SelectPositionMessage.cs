using System.Text;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectPositionMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => PositionAvailable.Count;
    public byte Player { get; }
    public uint CardCode { get; }
    public IReadOnlyList<CardPosition> PositionAvailable { get; }

    public SelectPositionMessage(byte player, uint cardCode, List<CardPosition> positionAvailable)
    {
        Player = player;
        CardCode = cardCode;
        PositionAvailable = positionAvailable;
    }
    
    public byte[] GetResponse(int id)
    {
        if (id < 0 || id >= PositionAvailable.Count)
            return [];
        var position = (uint) PositionAvailable[id];
        return BitConverter.GetBytes(position);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player} select a position for card {CardLibrary.GetCard(CardCode).Name}:");
        for (var i = 0; i < PositionAvailable.Count; i++)
        {
            sb.AppendLine($"[{i}] => {PositionAvailable[i]}");
        }

        return sb.ToString();
    }
}