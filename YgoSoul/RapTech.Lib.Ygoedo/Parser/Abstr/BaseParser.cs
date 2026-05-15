using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;

public abstract class BaseParser : IParser
{
    public IOcgMessage SafeParse(byte[] buffer)
    {
        try
        {
            Console.WriteLine("");
            Console.WriteLine($"Raw: {(GameMessage) buffer[0]} {BitConverter.ToString(buffer)}");
            return DoParse(buffer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new UnknownMessage(buffer);
        }
    }

    public IOcgMessage Parse(byte[] buffer)
    {
        Console.WriteLine($"Raw: {(GameMessage) buffer[0]} {BitConverter.ToString(buffer)}");
        return DoParse(buffer);
    }

    protected abstract IOcgMessage DoParse(byte[] buffer);
}