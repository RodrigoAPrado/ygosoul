using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SpecialSummonedMessage : SimpleTextMessage
{
    public SpecialSummonedMessage(string message = "Monster Special Summoned!") : base(message)
    {
    }
}