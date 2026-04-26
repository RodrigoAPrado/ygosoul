using YgoSoul.Message;
using YgoSoul.Parser;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Factory;

public static class ParserFactory
{
    public static Dictionary<GameMessage, IParser> CreateParsers()
    {
        var unknownParser = new UnknownParser();
        var basicParser = new BasicParser();
        var selectPlaceParser = new SelectPlaceParser();
        var selectYesNoParser = new SelectYesNoParser();
        var sortChainCardParser = new SortChainCardParser();
        var confirmCardParser = new ConfirmCardParser();
        var shuffleCardsParser = new ShuffleCardsParser();
        var summoningParser = new SummoningParser();
        
        return new Dictionary<GameMessage, IParser> 
        {
            { GameMessage.Unknown, unknownParser },
            { GameMessage.Retry, new RetryParser() },
            { GameMessage.Hint, new HintParser() },
            { GameMessage.SelectBattleCmd, new SelectBattleCmdParser() } ,
            { GameMessage.SelectIdleCmd, new SelectIdleCmdParser() } ,
            { GameMessage.SelectEffectYn, selectYesNoParser },
            { GameMessage.SelectYesNo, selectYesNoParser },
            { GameMessage.SelectOption, new SelectOptionParser() },
            { GameMessage.SelectCard, new SelectCardParser() },
            { GameMessage.SelectChain, new SelectChainParser() } ,
            { GameMessage.SelectPlace, selectPlaceParser } ,
            //Select Position
            { GameMessage.SelectTribute, new SelectTributeParser() },
            { GameMessage.SortChain, sortChainCardParser },
            { GameMessage.SelectCounter, new SelectCounterParser() },
            //{ GameMessage.SelectSum, new SelectSumParser() },
            { GameMessage.SelectDisfield, selectPlaceParser },
            { GameMessage.SortCard, sortChainCardParser },
            { GameMessage.SelectUnselectCard, new SelectUnselectedCardParser() },
            { GameMessage.ConfirmDeckTop, confirmCardParser },
            { GameMessage.ConfirmCards, confirmCardParser },
            { GameMessage.ShuffleDeck, basicParser },
            { GameMessage.ShuffleHand,  shuffleCardsParser},
            //Swapgrave
            //shuffle setcard
            { GameMessage.ReverseDeck, basicParser },
            { GameMessage.DeckTop, basicParser},
            { GameMessage.ShuffleExtra, shuffleCardsParser },
            { GameMessage.NewTurn, basicParser },
            { GameMessage.NewPhase, basicParser },
            { GameMessage.Move, new MoveParser() },
            { GameMessage.PosChange, basicParser },
            { GameMessage.Set, summoningParser },
            { GameMessage.Summoning, summoningParser },
            { GameMessage.Summoned, basicParser },
            { GameMessage.Chaining, new ChainingParser() },
            { GameMessage.Chained, basicParser },
            { GameMessage.Draw, new DrawParser()},
            { GameMessage.Damage, new DamageParser() },
            { GameMessage.Attack, new AttackParser() },
            { GameMessage.Battle, new BattleParser() },
            { GameMessage.DamageStepStart, basicParser },
            { GameMessage.DamageStepEnd, basicParser },
            { GameMessage.PlayerHint, new PlayerHintParser() }
        };
    }
}