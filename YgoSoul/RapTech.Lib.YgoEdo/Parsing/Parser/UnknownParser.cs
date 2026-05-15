using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class UnknownParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        return new UnknownMessage(buffer);
    }
}