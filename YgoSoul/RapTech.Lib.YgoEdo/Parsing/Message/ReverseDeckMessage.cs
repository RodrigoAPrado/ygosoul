using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ReverseDeckMessage : SimpleTextMessage
{
    public ReverseDeckMessage(string message = "Decks are reversed!") : base(message)
    {
    }
}