using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class SummoningMessage : SimpleTextMessage
{
    public SummoningMessage(string hint) : base(hint)
    {
    }
}