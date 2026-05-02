using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class ChainEndMessage : SimpleTextMessage
{
    public ChainEndMessage(string hint) : base(hint)
    {
    }
}