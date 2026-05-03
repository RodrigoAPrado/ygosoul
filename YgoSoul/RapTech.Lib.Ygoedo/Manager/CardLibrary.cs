using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;

namespace YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;

public class CardLibrary : ICardLibraryAccess
{
    private static readonly Dictionary<uint, CardData> Cards = new ();

    public static void AddCard(OCG_CardData data, string cardName, string cardText, List<string> strings, ulong category)
    {
        if (Cards.ContainsKey(data.code))
            return;
        Cards.Add(data.code, new CardData(data, cardName, cardText, strings, category));
    }

    public static bool HasCard(uint code)
    {
        return Cards.ContainsKey(code);
    }

    public static CardData InternalGetCard(uint code)
    {
        return code == 0 ? CardData.GetEmpty() : Cards[code];
    }

    public ICardData GetCard(uint code)
    {
        return code == 0 ? CardData.GetEmpty() : Cards[code];
    }

    public static IReadOnlyDictionary<uint, CardData> AllCards()
    {
        return Cards;
    }
}