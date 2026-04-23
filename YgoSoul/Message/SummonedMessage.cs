using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class SummonedMessage : SimpleTextMessage
{
    public SummonedMessage(string hint = "Monster Summoned!") : base(hint)
    {
    }
}