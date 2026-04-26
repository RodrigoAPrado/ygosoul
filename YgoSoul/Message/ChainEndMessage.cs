using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class ChainEndMessage : SimpleTextMessage
{
    public ChainEndMessage(string hint) : base(hint)
    {
    }
}