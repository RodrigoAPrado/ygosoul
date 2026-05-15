using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class FlipSummonedMessage : SimpleTextMessage
{
    public FlipSummonedMessage(string message = "Monster Flip Summoned!") : base(message)
    {
    }
}