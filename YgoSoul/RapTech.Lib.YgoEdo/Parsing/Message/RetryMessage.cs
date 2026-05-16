using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class RetryMessage : SimpleTextMessage
{
    public override InputType Input => InputType.Retry;
    
    public RetryMessage(string message) : base(message)
    {
    }
}