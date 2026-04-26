namespace YgoSoul.Handler;

public class DescriptionHandler
{
    public static string GetDescription(ulong value)
    {
        if (System.Enum.IsDefined(typeof(GameHintEvent), value))
        {
            return ((GameHintEvent)value).ToString();
        }

        var cardId = (uint)(value >> 32);
        var stringId = (int)(value & 0xFFFFFFFF);
        return CardLibrary.GetCard(cardId).Strings[stringId];
    }
}