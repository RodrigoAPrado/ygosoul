using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class RetryMessage : SimpleTextMessage
{
    public override InputType Input => InputType.Retry;
    
    public RetryMessage(string hint) : base(hint)
    {
    }
}