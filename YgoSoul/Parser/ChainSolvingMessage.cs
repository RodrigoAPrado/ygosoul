using YgoSoul.Message.Abstr;

namespace YgoSoul.Parser;

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