using YgoSoul.Message.Enum;

namespace YgoSoul.Message.Abstr;

public abstract class BaseMessage : IMessage
{
    public virtual InputType Input => InputType.None;
    public virtual byte[] GetResponse(int id) => [0xFF];
}