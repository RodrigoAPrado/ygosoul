using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class ChainDisabledMessage : BaseMessage
{
    public byte ChainSize { get; }

    public ChainDisabledMessage(byte chainSize)
    {
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"ChainDisabled, ChainSize={ChainSize}";
    }
}