using YgoSoul.Parser;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Factory;

public static class ParserFactory
{
    public static Dictionary<GameMessage, IParser> CreateParsers()
    {
        return new Dictionary<GameMessage, IParser> 
        {
            { GameMessage.Unknown, new UnknownParser() },
            { GameMessage.SelectIdleCmd, new SelectIdleCmdParser() } 
        };
    }
}