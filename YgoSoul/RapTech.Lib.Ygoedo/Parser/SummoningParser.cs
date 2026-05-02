using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

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
            case GameMessage.SpSummoning:
                return new SpecialSummoningMessage(cardCode, player, location, sequence, position);
            case GameMessage.FlipSummoning:
                return new FlipSummoningMessage(cardCode, player, location, sequence, position);
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
}