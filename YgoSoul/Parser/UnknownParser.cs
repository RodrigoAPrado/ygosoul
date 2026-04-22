using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class UnknownParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        return new UnknownMessage(buffer);
    }
}