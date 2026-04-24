using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class RetryParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        return new RetryMessage("Invalid command! Please, try again!");
    }
}