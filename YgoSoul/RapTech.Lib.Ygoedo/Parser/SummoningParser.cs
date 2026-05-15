using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class SummoningParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var messageType = (GameMessage)reader.ReadByte(); //msg
        var cardCode = reader.ReadUInt32();
        
        var player = reader.ReadByte();
        var location = (CardLocation) reader.ReadByte();
        var sequence = reader.ReadUInt32();
        var position = (CardPosition) reader.ReadUInt32();

        var card = new CardReference(cardCode, new FullLocationReference(player, location, sequence, position), 0);

        switch (messageType)
        {
            case GameMessage.Summoning:
                return new SummoningMessage(card);
            case GameMessage.Set:
                return new SetMessage(card);
            case GameMessage.SpSummoning:
                return new SpecialSummoningMessage(card);
            case GameMessage.FlipSummoning:
                return new FlipSummoningMessage(card);
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
}