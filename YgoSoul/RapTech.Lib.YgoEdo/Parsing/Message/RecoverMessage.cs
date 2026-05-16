using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class RecoverMessage : BaseMessage, IRecoverMessage
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