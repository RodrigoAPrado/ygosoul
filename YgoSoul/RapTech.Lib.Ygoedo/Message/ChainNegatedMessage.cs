using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class ChainNegatedMessage : BaseMessage
{
    public byte ChainSize { get; }

    public ChainNegatedMessage(byte chainSize)
    {
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"Chain Negated, Chain Size={ChainSize}";
    }
}