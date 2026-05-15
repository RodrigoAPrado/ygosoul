using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ChainEndMessage : SimpleTextMessage
{
    public ChainEndMessage(string message) : base(message)
    {
    }
}