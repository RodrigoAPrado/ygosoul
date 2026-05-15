using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;

public interface IParser
{
    IOcgMessage SafeParse(byte[] buffer);
    IOcgMessage Parse(byte[] buffer);
}