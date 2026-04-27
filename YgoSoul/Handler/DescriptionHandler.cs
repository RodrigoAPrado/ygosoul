using YgoSoul.Util;

namespace YgoSoul.Handler;

public class DescriptionHandler
{
    public static string GetDescription(ulong value)
    {
        var buffer = BitConverter.GetBytes(value);
        var reader = new PacketReader(buffer);
        var stringId = reader.ReadUInt16();
        
        if (System.Enum.IsDefined(typeof(GameHintEvent), (ulong)stringId))
        {
            return ((GameHintEvent)value).ToString();
        }
        
        var cardIdRaw = reader.ReadUInt32();
        var cardId = cardIdRaw >> 4;

        if (cardId == 0)
            return "Activate";
        
        return CardLibrary.GetCard(cardId).Strings[stringId];
    }
}