using YgoSoul.Message.Abstr;

namespace YgoSoul.Parser.Abstr;

public interface IParser
{
    IMessage? Parse(byte[] buffer);
}