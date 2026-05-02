using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectPlaceParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msg = (GameMessage) reader.ReadByte();
        var player = reader.ReadByte();
        var amount = reader.ReadByte();
        var mask = reader.ReadUInt32();

        var zones = new List<Zone>();
        
        for (int i = 0; i < 32; i++)
        {
            if ((mask & (1u << i)) == 0)
            {
                zones.Add((Zone)(1u << i));
            }
        }

        switch (msg)
        {
            case GameMessage.SelectPlace:
                return new SelectPlaceMessage(player, amount, zones);
            case GameMessage.SelectDisfield:
                return new SelectDisfieldMessage(player, amount, zones);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}