using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class BasicParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msgType = (GameMessage) reader.ReadByte();
        switch (msgType)
        {
            case GameMessage.NewTurn:
                return new NewTurnMessage(reader.ReadByte());
            case GameMessage.NewPhase:
                return new NewPhaseMessage((GamePhases) reader.ReadByte());
            case GameMessage.ShuffleDeck:
                return new ShuffleDeckMessage(reader.ReadByte());
            case GameMessage.ReverseDeck:
                return new ReverseDeckMessage();
            case GameMessage.Swap:
                return new SwapMessage(new CardReference(
                    reader.ReadUInt32(), 
                    reader.ReadByte(), 
                    (CardLocation)reader.ReadByte(), 
                    reader.ReadUInt32(), 
                    (CardPosition)reader.ReadUInt32(), 
                    0
                ), new CardReference(
                    reader.ReadUInt32(), 
                    reader.ReadByte(), 
                    (CardLocation)reader.ReadByte(), 
                    reader.ReadUInt32(), 
                    (CardPosition)reader.ReadUInt32(), 
                    0
                ));
            case GameMessage.FieldDisabled:
                return new FieldDisabledMessage(reader.ReadUInt32());
            case GameMessage.Summoned:
                return new SummonedMessage();
            case GameMessage.SpSummoned:
                return new SpecialSummonedMessage();
            case GameMessage.FlipSummoned:
                return new FlipSummonedMessage();
            case GameMessage.Chained:
                return new ChainedMessage(reader.ReadByte());
            case GameMessage.ChainSolving:
                return new ChainSolvingMessage(reader.ReadByte());
            case GameMessage.ChainSolved:
                return new ChainSolvedMessage(reader.ReadByte());
            case GameMessage.ChainEnd:
                return new ChainEndMessage("Chain End.");
            case GameMessage.ChainNegated:
                return new ChainNegatedMessage(reader.ReadByte());
            case GameMessage.ChainDisabled:
                return new ChainDisabledMessage(reader.ReadByte());
            case GameMessage.DeckTop:
                var player = reader.ReadByte();
                reader.ReadUInt32();//vazio
                return new DeckTopMessage(player, reader.ReadUInt32(), (CardPosition) reader.ReadUInt32());
            case GameMessage.PosChange:
                return new PosChangeMessage(
                    reader.ReadUInt32(), 
                    reader.ReadByte(), 
                    (CardLocation) reader.ReadByte(),
                    reader.ReadByte(),
                    (CardPosition) reader.ReadByte(),
                    (CardPosition) reader.ReadByte());
            case GameMessage.Damage:
                return new DamageMessage(reader.ReadByte(), reader.ReadUInt32());
            case GameMessage.Recover:
                return new RecoverMessage(reader.ReadByte(), reader.ReadUInt32());
            case GameMessage.Equip:
                return new EquipMessage(new FullLocationReference(
                    reader.ReadByte(), 
                    (CardLocation) reader.ReadByte(),
                    reader.ReadUInt32(),
                    (CardPosition) reader.ReadUInt32()),
                    new FullLocationReference(
                    reader.ReadByte(), 
                    (CardLocation) reader.ReadByte(),
                    reader.ReadUInt32(),
                    (CardPosition) reader.ReadUInt32()));
            case GameMessage.LpUpdate:
                return new LpUpdateMessage(reader.ReadByte(), reader.ReadUInt32());
            case GameMessage.CardTarget:
                return new CardTargetMessage(new FullLocationReference(
                        reader.ReadByte(), 
                        (CardLocation) reader.ReadByte(),
                        reader.ReadUInt32(),
                        (CardPosition) reader.ReadUInt32()),
                    new FullLocationReference(
                        reader.ReadByte(), 
                        (CardLocation) reader.ReadByte(),
                        reader.ReadUInt32(),
                        (CardPosition) reader.ReadUInt32()));
            case GameMessage.CancelTarget:
                return new CancelTargetMessage(new FullLocationReference(
                        reader.ReadByte(), 
                        (CardLocation) reader.ReadByte(),
                        reader.ReadUInt32(),
                        (CardPosition) reader.ReadUInt32()),
                    new FullLocationReference(
                        reader.ReadByte(), 
                        (CardLocation) reader.ReadByte(),
                        reader.ReadUInt32(),
                        (CardPosition) reader.ReadUInt32()));
            case GameMessage.PayLpCost:
                return new PayLpCostMessage(reader.ReadByte(), reader.ReadUInt32());
            case GameMessage.AttackDisabled:
                return new AttackDisabled();
            case GameMessage.DamageStepStart:
                return new DamageStepStartMessage();
            case GameMessage.DamageStepEnd:
                return new DamageStepEndMessage();
            case GameMessage.MissedEffect:
                return new MissedEffectMessage(new FullLocationReference(
                    reader.ReadByte(), 
                    (CardLocation) reader.ReadByte(), 
                    reader.ReadUInt32(), 
                    (CardPosition) reader.ReadUInt32()), 
                    reader.ReadUInt32()
                    );
            case GameMessage.CardHint:
                return new CardHintMessage(new FullLocationReference(
                    reader.ReadByte(), 
                    (CardLocation) reader.ReadByte(),
                    reader.ReadUInt32(),
                    (CardPosition) reader.ReadUInt32()),
                    (CardHint) reader.ReadByte(),
                    reader.ReadULong64());
            default:
                return new UnknownMessage(buffer);
        }
    }
}