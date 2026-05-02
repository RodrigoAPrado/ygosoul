using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class FlipSummonedMessage : SimpleTextMessage
{
    public FlipSummonedMessage(string hint = "Monster Flip Summoned!") : base(hint)
    {
    }
}