using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class UnknownParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        return new UnknownMessage(buffer);
    }
}