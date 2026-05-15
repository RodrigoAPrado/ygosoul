using YgoSoul.RapTech.Lib.Ygoedo.Handler.Enum;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Handler;

public class MessageHandler
{
    public static IOcgMessage? MessageRequiringInput { get; private set; }
    
    public static MessageHandleEnum HandleMessage(IOcgMessage message)
    {
        if (message == null)
            throw new InvalidOperationException("Message is null");

        Console.WriteLine(message.ToString());
        
        if (message.Input == InputType.Unknown)
            return MessageHandleEnum.Invalid;
        
        if (message.Input == InputType.None)
        {
            MessageRequiringInput = null;
            return MessageHandleEnum.Proceed;
        }

        if (message.Input == InputType.Retry)
            return MessageHandleEnum.RequireInput;
        
        MessageRequiringInput = message;
        return MessageHandleEnum.RequireInput;
    }
}