using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SummonedMessage : SimpleTextMessage
{
    public SummonedMessage(string message = "Monster Summoned!") : base(message)
    {
    }
}