using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SummonedMessage : SimpleTextMessage
{
    public SummonedMessage(string message = "Monster Summoned!") : base(message)
    {
    }
}