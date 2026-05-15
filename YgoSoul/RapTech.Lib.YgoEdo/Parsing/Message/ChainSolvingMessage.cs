using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

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