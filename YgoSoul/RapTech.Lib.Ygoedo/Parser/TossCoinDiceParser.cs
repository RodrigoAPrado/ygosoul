using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class TossCoinDiceParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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