using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class RetryParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        return new RetryMessage("Invalid command! Please, try again!");
    }
}