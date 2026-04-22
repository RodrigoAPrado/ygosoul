using YgoSoul.Handler.Enum;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Handler;

public class MessageHandler
{
    public static IMessage? CurrentMessage => _messagesList.FirstOrDefault();
    private static readonly List<IMessage> _messagesList = [];
    
    public static MessageHandleEnum HandleMessage(IMessage? message)
    {
        if (message == null)
            return MessageHandleEnum.Invalid;

        Console.Write(message.ToString());

        if (!message.RequiresInput) 
            return MessageHandleEnum.Proceed;
        
        _messagesList.Add(message);
        return MessageHandleEnum.RequireInput;
    }

    public static bool ReleaseMessage()
    {
        if (_messagesList.Count == 0)
            return false;
        _messagesList.RemoveAt(0);
        return true;
    }
}