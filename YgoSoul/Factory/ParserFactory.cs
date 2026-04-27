using YgoSoul.DuelRunner;
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
        var positionListParser = new PositionListParser();
        var changeCounterParser = new ChangeCounterParser();
        var tossCoinDiceParser = new TossCoinDiceParser();
        
        return new Dictionary<GameMessage, IParser> 
        {
            { GameMessage.Unknown, unknownParser },
            { GameMessage.Retry, new RetryParser() },
            { GameMessage.Hint, new HintParser() },
            { GameMessage.Win, new WinParser() },
            { GameMessage.SelectBattleCmd, new SelectBattleCmdParser() } ,
            { GameMessage.SelectIdleCmd, new SelectIdleCmdParser() } ,
            { GameMessage.SelectEffectYn, selectYesNoParser },
            { GameMessage.SelectYesNo, selectYesNoParser },
            { GameMessage.SelectOption, new SelectOptionParser() },
            { GameMessage.SelectCard, new SelectCardParser() },
            { GameMessage.SelectChain, new SelectChainParser() } ,
            { GameMessage.SelectPlace, selectPlaceParser } ,
            { GameMessage.SelectPosition, new SelectPositionParser() },
            { GameMessage.SelectTribute, new SelectTributeParser() },
            { GameMessage.SortChain, sortChainCardParser },
            { GameMessage.SelectCounter, new SelectCounterParser() },
            { GameMessage.SelectDisfield, selectPlaceParser },
            { GameMessage.SortCard, sortChainCardParser },
            { GameMessage.SelectUnselectCard, new SelectUnselectedCardParser() },
            { GameMessage.ConfirmDeckTop, confirmCardParser },
            { GameMessage.ConfirmCards, confirmCardParser },
            { GameMessage.ShuffleDeck, basicParser },
            { GameMessage.ShuffleHand,  shuffleCardsParser},
            { GameMessage.ReverseDeck, basicParser },
            { GameMessage.DeckTop, basicParser},
            { GameMessage.ShuffleExtra, shuffleCardsParser },
            { GameMessage.NewTurn, basicParser },
            { GameMessage.NewPhase, basicParser },
            { GameMessage.ConfirmExtraTop, confirmCardParser },
            { GameMessage.Move, new MoveParser() },
            { GameMessage.PosChange, basicParser },
            { GameMessage.Set, summoningParser },
            { GameMessage.Swap, basicParser },
            { GameMessage.FieldDisabled, basicParser },
            { GameMessage.Summoning, summoningParser },
            { GameMessage.Summoned, basicParser },
            { GameMessage.SpSummoning, summoningParser },
            { GameMessage.SpSummoned, basicParser },
            { GameMessage.FlipSummoning, summoningParser },
            { GameMessage.FlipSummoned, basicParser },
            { GameMessage.Chaining, new ChainingParser() },
            { GameMessage.Chained, basicParser },
            { GameMessage.ChainSolving, basicParser },
            { GameMessage.ChainSolved, basicParser },
            { GameMessage.ChainEnd, basicParser },
            { GameMessage.ChainNegated, basicParser },
            { GameMessage.ChainDisabled, basicParser },
            { GameMessage.CardSelected, positionListParser },
            { GameMessage.BecomeTarget, positionListParser },
            { GameMessage.Draw, new DrawParser() },
            { GameMessage.Damage, basicParser },
            { GameMessage.Recover, basicParser },
            { GameMessage.Equip, basicParser },
            { GameMessage.LpUpdate, basicParser },
            { GameMessage.CardTarget, basicParser },
            { GameMessage.CancelTarget, basicParser },
            { GameMessage.PayLpCost, basicParser },
            { GameMessage.AddCounter, changeCounterParser },
            { GameMessage.RemoveCounter, changeCounterParser },
            { GameMessage.Attack, new AttackParser() },
            { GameMessage.Battle, new BattleParser() },
            { GameMessage.AttackDisabled, basicParser},
            { GameMessage.DamageStepStart, basicParser },
            { GameMessage.DamageStepEnd, basicParser },
            { GameMessage.MissedEffect, basicParser },
            { GameMessage.TossCoin, tossCoinDiceParser },
            { GameMessage.TossDice, tossCoinDiceParser },
            { GameMessage.CardHint, basicParser },
            { GameMessage.PlayerHint, new PlayerHintParser() }
        };
    }
}