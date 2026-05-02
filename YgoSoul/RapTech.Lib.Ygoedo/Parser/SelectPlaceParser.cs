using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

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