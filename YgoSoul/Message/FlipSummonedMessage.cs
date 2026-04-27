using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class FlipSummonedMessage : SimpleTextMessage
{
    public FlipSummonedMessage(string hint = "Monster Flip Summoned!") : base(hint)
    {
    }
}