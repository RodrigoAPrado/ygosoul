using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SpecialSummonedMessage : SimpleTextMessage
{
    public SpecialSummonedMessage(string message = "Monster Special Summoned!") : base(message)
    {
    }
}