using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class ChainSolvingMessage : BaseMessage
{
    public byte ChainLink { get; }

    public ChainSolvingMessage(byte chainLink)
    {
        ChainLink = chainLink;
    }

    public override string ToString()
    {
        return $"SolvingChain, ChainLink={ChainLink}";
    }
}