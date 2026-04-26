using System.Text;
using YgoSoul.Handler;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectOptionMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Options.Count;
    public byte Player { get; }
    public IReadOnlyList<ulong> Options { get; }

    public SelectOptionMessage(byte player, List<ulong> options)
    {
        Player = player;
        Options = options;
    }
    
    public byte[] GetResponse(int id)
    {
        if (id < 0 || id >= Options.Count)
            return [];

        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player: {Player}, here are your options:");

        for (var i = 0; i < Options.Count; i++)
        {
            sb.AppendLine($"[{i}] => {DescriptionHandler.GetDescription(Options[i])}");
        }
        return sb.ToString();
    }
}