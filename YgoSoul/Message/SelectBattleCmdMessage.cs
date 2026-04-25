using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectBattleCmdMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Choices.Count;
    public byte Player { get; }
    public IReadOnlyList<BattleCmdChoice> Choices { get; }

    public SelectBattleCmdMessage(byte player, List<BattleCmdChoice> choices)
    {
        Player = player;
        Choices = choices;
    }
    
    public byte[] GetResponse(int id)
    {
        
        if (id >= Choices.Count)
            return new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };

        var choice = Choices[id];

        uint value = (choice.Index << 16) | (uint)choice.Action;

        return BitConverter.GetBytes(value); 
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player}, input your action:");
        for (int i = 0; i < Choices.Count; i++)
        {
            sb.AppendLine($"{i} -> {Choices[i]}");
        }
        return sb.ToString();
    }
}