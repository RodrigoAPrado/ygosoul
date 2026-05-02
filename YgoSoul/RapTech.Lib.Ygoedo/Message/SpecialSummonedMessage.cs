using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class SpecialSummonedMessage : SimpleTextMessage
{
    public SpecialSummonedMessage(string hint = "Monster Special Summoned!") : base(hint)
    {
    }
}