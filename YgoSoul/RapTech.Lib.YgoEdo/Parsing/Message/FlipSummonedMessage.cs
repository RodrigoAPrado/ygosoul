using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class FlipSummonedMessage : SimpleTextMessage
{
    public FlipSummonedMessage(string message = "Monster Flip Summoned!") : base(message)
    {
    }
}