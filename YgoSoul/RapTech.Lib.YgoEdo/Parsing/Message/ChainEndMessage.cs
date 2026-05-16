using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ChainEndMessage : SimpleTextMessage, IChainEndMessage
{
    public ChainEndMessage(string message) : base(message)
    {
    }
}