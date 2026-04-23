using YgoSoul.Parser;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Factory;

public static class ParserFactory
{
    public static Dictionary<GameMessage, IParser> CreateParsers()
    {
        var unknownParser = new UnknownParser();
        var basicParser = new BasicParser();
        
        return new Dictionary<GameMessage, IParser> 
        {
            { GameMessage.Unknown, unknownParser },
            { GameMessage.Retry, unknownParser },
            { GameMessage.Hint, new HintParser() },
            { GameMessage.SelectIdleCmd, new SelectIdleCmdParser() } ,
            { GameMessage.SelectChain, unknownParser } ,
            { GameMessage.NewTurn, basicParser },
            { GameMessage.NewPhase, basicParser }
        };
    }
}