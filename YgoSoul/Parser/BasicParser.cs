using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
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
            case GameMessage.Summoned:
                return new SummonedMessage();
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
            case GameMessage.DamageStepStart:
                return new DamageStepStartMessage();
            case GameMessage.DamageStepEnd:
                return new DamageStepEndMessage();
            default:
                return new UnknownMessage(buffer);
        }
    }
}