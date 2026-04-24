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
            { GameMessage.Retry, new RetryParser() },
            { GameMessage.Hint, new HintParser() },
            { GameMessage.SelectIdleCmd, new SelectIdleCmdParser() } ,
            { GameMessage.SelectChain, new SelectChainParser() } ,
            { GameMessage.SelectPlace, new SelectPlaceParser() } ,
            { GameMessage.NewTurn, basicParser },
            { GameMessage.NewPhase, basicParser },
            { GameMessage.Move, new MoveParser() },
            { GameMessage.Summoning, new SummoningParser() },
            { GameMessage.Summoned, new SummonedParser() },
            { GameMessage.Draw, new DrawParser() }
        };
    }
}