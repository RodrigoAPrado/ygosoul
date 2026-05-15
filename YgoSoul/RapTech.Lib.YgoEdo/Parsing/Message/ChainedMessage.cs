using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ChainedMessage : BaseMessage
{
    public byte ChainSize { get; }

    public ChainedMessage(byte chainSize)
    {
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"Chain Size={ChainSize}";
    }
}