using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class SelectPositionParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var cardCode = reader.ReadUInt32();
        var mask = reader.ReadByte();
        var availablePositions = new List<CardPosition>();
        
        foreach (CardPosition pos in Enum.GetValues(typeof(CardPosition)))
        {
            switch (pos)
            {
                case CardPosition.FaceUpAttack:
                case CardPosition.FaceDownAttack:
                case CardPosition.FaceUpDefense:
                case CardPosition.FaceDownDefense:
                    if ((mask & (byte)pos) != 0)
                        availablePositions.Add(pos);
                    break;
                default:
                    continue;
            }
        }

        return new SelectPositionMessage(player, cardCode, availablePositions);
    }
}