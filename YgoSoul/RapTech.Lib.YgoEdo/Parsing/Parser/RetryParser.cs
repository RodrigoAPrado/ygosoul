using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class RetryParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        return new RetryMessage("Invalid command! Please, try again!");
    }
}