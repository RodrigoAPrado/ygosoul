using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Handler;

public class DescriptionHandler
{
    public static string GetDescription(ulong value)
    {
        try
        {
            if(value == 0) 
                return "Activate";

            var stringId = (value & 0xfffff);
            var cardId = (uint) (value >> 20);
            
            if (CardLibrary.HasCard(cardId))
            {
                return CardLibrary.InternalGetCard(cardId).Strings[(int) stringId];
            }

            if (System.Enum.IsDefined(typeof(GameStrings), stringId))
            {
                return ((GameStrings)value).ToString();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return $"{value:x16}";
    }

    public static string GetDescription(ulong value, CardHint hint)
    {
        switch (hint)
        {
            case CardHint.Turn:
            case CardHint.Card:
                var cardCode = (uint)value;
                return CardLibrary.InternalGetCard(cardCode).Name;
            case CardHint.Race:
                return $"{(MonsterRaces)value}";
            case CardHint.Attribute:
                return $"{(MonsterAttributes)value}";
            case CardHint.Number:
            case CardHint.DescAdd:
                return $"{(GameStrings)value}";
            case CardHint.DescRemove:
                return $"{(GameStrings)value}";
            default:
                throw new ArgumentOutOfRangeException(nameof(hint), hint, null);
        }
    }
}