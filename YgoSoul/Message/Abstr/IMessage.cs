using YgoSoul.Message.Enum;

namespace YgoSoul.Message.Abstr;

public interface IMessage
{
    InputType Input { get; }
    byte[] GetResponse(int id);
}