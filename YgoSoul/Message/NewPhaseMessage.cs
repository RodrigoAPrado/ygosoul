using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class NewPhaseMessage : SimpleTextMessage
{
    public NewPhaseMessage(string hint) : base(hint)
    {
    }
}