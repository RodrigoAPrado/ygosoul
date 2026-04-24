using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class RetryMessage : SimpleTextMessage
{
    public override InputType Input => InputType.Retry;
    
    public RetryMessage(string hint) : base(hint)
    {
    }
}