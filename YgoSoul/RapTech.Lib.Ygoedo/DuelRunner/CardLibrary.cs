namespace YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;

public static class CardLibrary
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

    public static CardData GetCard(uint code)
    {
        return code == 0 ? CardData.GetEmpty() : Cards[code];
    }

    public static IReadOnlyDictionary<uint, CardData> AllCards()
    {
        return Cards;
    }
}

public class CardData
{
    public OCG_CardData Data { get; }
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<string> Strings { get; }
    public ulong Category { get; }
    private static readonly CardData EmptyData = new CardData(new OCG_CardData(), "Monster", "", [], 0);

    public CardData(OCG_CardData data, string name, string description, List<string> strings, ulong category)
    {
        Data = data;
        Name = name;
        Description = description;
        Strings = strings;
        Category = category;
    }

    public static CardData GetEmpty()
    {
        return EmptyData;
    }
}