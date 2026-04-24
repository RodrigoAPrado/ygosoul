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
        if (id >= Choices.Count)
        {
            return [0xFF, 0xFF, 0xFF, 0xFF];
        }
        var choice = Choices[id];
        byte[] response = new byte[4];
        response[0] = (byte)choice.PlayerAction;
        response[1] = choice.Player;
        response[2] = (byte)choice.ValueIndex;
        return response;
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