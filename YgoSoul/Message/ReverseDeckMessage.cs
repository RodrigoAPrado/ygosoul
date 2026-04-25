using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class ReverseDeckMessage : SimpleTextMessage
{
    public ReverseDeckMessage(string hint = "Decks are reversed!") : base(hint)
    {
    }
}