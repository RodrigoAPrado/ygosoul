using YgoSoul.Handler.Enum;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Handler;

public class MessageHandler
{
    public static IMessage? MessageRequiringInput { get; private set; }
    
    public static MessageHandleEnum HandleMessage(IMessage message)
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