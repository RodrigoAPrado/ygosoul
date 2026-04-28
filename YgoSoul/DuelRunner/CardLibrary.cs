namespace YgoSoul.DuelRunner;

public static class CardLibrary
{
    private static readonly Dictionary<uint, CardData> Cards = new ();

    public static void AddCard(OCG_CardData data, string cardName, string cardText, List<string> strings)
    {
        if (Cards.ContainsKey(data.code))
            return;
        Cards.Add(data.code, new CardData(data, cardName, cardText, strings));
    }

    public static CardData GetCard(uint code)
    {
        return Cards[code];
    }
}

public class CardData
{
    public OCG_CardData Data { get; }
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<string> Strings { get; }

    public CardData(OCG_CardData data, string name, string description, List<string> strings)
    {
        Data = data;
        Name = name;
        Description = description;
        Strings = strings;
    }
}