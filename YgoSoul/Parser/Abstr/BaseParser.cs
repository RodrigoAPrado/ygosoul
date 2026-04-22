using YgoSoul.Message.Abstr;

namespace YgoSoul.Parser.Abstr;

public abstract class BaseParser : IParser
{
    public IMessage? Parse(byte[] buffer)
    {
        try
        {
            return DoParse(buffer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    protected abstract IMessage DoParse(byte[] buffer);
}