using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectIdleCmdMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Choices.Count;
    public IReadOnlyList<IIdleCmdChoice> Choices { get; }
    public byte Player { get; }
    
    public SelectIdleCmdMessage(byte player, List<IIdleCmdChoice> choices)
    {
        Choices = choices;
        Player = player;
    }

    public byte[] GetResponse(int id)
    {
        if (id < 0 || id >= Choices.Count)
            return [];

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
            sb.AppendLine($"[{i}] => {Choices[i]}");
        }
        return sb.ToString();
    }
}