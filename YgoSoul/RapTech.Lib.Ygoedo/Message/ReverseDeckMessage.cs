using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class ReverseDeckMessage : SimpleTextMessage
{
    public ReverseDeckMessage(string hint = "Decks are reversed!") : base(hint)
    {
    }
}