using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;

namespace YgoSoul.RapTech.Lib.YgoEdo.Handler;

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

            if (System.Enum.IsDefined(typeof(OCG_GameStrings), stringId))
            {
                return ((OCG_GameStrings)value).ToString();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return $"{value:x16}";
    }

    public static string GetDescription(ulong value, OCG_CardHint hint)
    {
        switch (hint)
        {
            case OCG_CardHint.Turn:
            case OCG_CardHint.Card:
                var cardCode = (uint)value;
                return CardLibrary.InternalGetCard(cardCode).Name;
            case OCG_CardHint.Race:
                return $"{(OCG_MonsterRaces)value}";
            case OCG_CardHint.Attribute:
                return $"{(OCG_MonsterAttributes)value}";
            case OCG_CardHint.Number:
            case OCG_CardHint.DescAdd:
                return $"{(OCG_GameStrings)value}";
            case OCG_CardHint.DescRemove:
                return $"{(OCG_GameStrings)value}";
            default:
                throw new ArgumentOutOfRangeException(nameof(hint), hint, null);
        }
    }
}