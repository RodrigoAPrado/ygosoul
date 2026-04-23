using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class HintMessage : SimpleTextMessage
{
    public HintMessage(string hint) : base(hint)
    {
    }
}