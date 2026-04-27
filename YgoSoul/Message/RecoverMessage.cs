using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class RecoverMessage : BaseMessage
{
    public byte Player { get; }
    public uint Recover { get; }
    
    public RecoverMessage(byte player, uint damage)
    {
        Player = player;
        Recover = damage;
    }

    public override string ToString()
    {
        return $"Player: {Player}, recovered {Recover} LP!";
    }
}