using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class ChangeCounterParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msg = (GameMessage) reader.ReadByte();//msg
        var counterType = (CounterType) reader.ReadUInt16();
        var player = reader.ReadByte();
        var location = (CardLocation) reader.ReadByte();
        var sequence = reader.ReadByte();
        var count = reader.ReadUInt16();

        switch (msg)
        {
            case GameMessage.AddCounter:
                return new AddCounterMessage(counterType, player, location, sequence, count);
            case GameMessage.RemoveCounter:
                return new RemoveCounterMessage(counterType, player, location, sequence, count);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}