using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class ReverseDeckMessage : SimpleTextMessage
{
    public ReverseDeckMessage(string message = "Decks are reversed!") : base(message)
    {
    }
}