using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class WinMessage : IMessage
{
    public InputType Input => InputType.Win;
    public int InputCount => 0;
    public byte Player { get; }
    public byte Reason { get; }

    public WinMessage(byte player, byte reason)
    {
        Player = player;
        Reason = reason;
    }
    
    public byte[] GetResponse(int id)
    {
        return [];
    }

    public override string ToString()
    {
        return $"Player {Player} won the duel! Reason: {Reason}";
    }
}