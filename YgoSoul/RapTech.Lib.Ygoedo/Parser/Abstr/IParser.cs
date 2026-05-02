using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;

public interface IParser
{
    IMessage? Parse(byte[] buffer);
}