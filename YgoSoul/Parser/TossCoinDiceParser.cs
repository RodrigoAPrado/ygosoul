using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class TossCoinDiceParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var message = (GameMessage) reader.ReadByte();//msg
        var player = reader.ReadByte();
        var count = reader.ReadByte();

        switch (message)
        {
            case GameMessage.TossCoin:
                return GetTossCoin(reader, player, count);
            case GameMessage.TossDice:
                return GetTossDice(reader, player, count);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private TossCoinMessage GetTossCoin(PacketReader reader, byte player, byte count)
    {
        var results = new List<CoinResult>();
        for (var i = count; i > 0; i--)
        {
            results.Add((CoinResult) reader.ReadByte());
        }

        return new TossCoinMessage(player, results);
    }

    private TossDiceMessage GetTossDice(PacketReader reader, byte player, byte count)
    {
        var results = new List<byte>();
        for (var i = count; i > 0; i--)
        {
            results.Add(reader.ReadByte());
        }

        return new TossDiceMessage(player, results);
    }
}