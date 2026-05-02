using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class HintMessage : SimpleTextMessage
{
    public HintMessage(string hint) : base(hint)
    {
    }
}