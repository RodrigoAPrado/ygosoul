using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;

public interface IParser
{
    IOcgMessage SafeParse(byte[] buffer);
    IOcgMessage Parse(byte[] buffer);
}