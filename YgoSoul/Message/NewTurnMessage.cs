using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class NewTurnMessage : SimpleTextMessage
{
    public NewTurnMessage(string hint) : base(hint)
    {
    }
}