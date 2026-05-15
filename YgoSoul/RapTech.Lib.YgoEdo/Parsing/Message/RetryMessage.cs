using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class RetryMessage : SimpleTextMessage
{
    public override InputType Input => InputType.Retry;
    
    public RetryMessage(string message) : base(message)
    {
    }
}