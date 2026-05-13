using System.Diagnostics;
using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class SortChainCardParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msg = (GameMessage) reader.ReadByte();//msg
        var player = reader.ReadByte();
        var count = reader.ReadUInt32();

        var cards = new List<CardReference>();
        
        for (var i = count; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadUInt32();
            var sequence = reader.ReadUInt32();
            cards.Add(new CardReference(cardCode, new FullLocationReference(controller, location, sequence, 0), count -i));
        }
        
        return msg switch
        {
            GameMessage.SortCard => new SortCardMessage(player, cards),
            GameMessage.SortChain => new SortChainMessage(player, cards),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}