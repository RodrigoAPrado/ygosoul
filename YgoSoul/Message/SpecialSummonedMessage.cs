using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class SpecialSummonedMessage : SimpleTextMessage
{
    public SpecialSummonedMessage(string hint = "Monster Special Summoned!") : base(hint)
    {
    }
}