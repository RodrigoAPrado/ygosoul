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
        {
            return [0xFF,0xFF,0xFF,0xFF];
        }

        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        return $"Player: {Player}, Options: {string.Join("\n-", Options)}";
    }
}