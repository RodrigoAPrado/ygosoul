using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class SummonedMessage : SimpleTextMessage
{
    public SummonedMessage(string hint = "Monster Summoned!") : base(hint)
    {
    }
}