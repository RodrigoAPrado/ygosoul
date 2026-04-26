using YgoSoul.Message;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Parser.Abstr;

public abstract class BaseParser : IParser
{
    public IMessage Parse(byte[] buffer)
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
    
    protected abstract IMessage DoParse(byte[] buffer);
}