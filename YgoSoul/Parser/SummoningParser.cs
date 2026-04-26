using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SummoningParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var messageType = (GameMessage)reader.ReadByte(); //msg
        var cardCode = reader.ReadUInt32();
        
        var player = reader.ReadByte();
        var location = (CardLocation) reader.ReadByte();
        var sequence = reader.ReadUInt32();
        var position = (CardPosition) reader.ReadUInt32();

        switch (messageType)
        {
            case GameMessage.Summoning:
                return new SummoningMessage(cardCode, player, location, sequence, position);
            case GameMessage.Set:
                return new SetMessage(cardCode, player, location, sequence, position);
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
}