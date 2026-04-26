namespace YgoSoul;

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
    public uint Code { get; }
    public uint Alias { get; }
    public uint Type { get; }
    public uint Level { get; }
    public uint Attribute { get; }
    public ulong Race { get; }
    public int Attack { get; }
    public int Defense { get; }
    public uint LeftScale { get; }
    public uint RightScale { get; }
    public uint LinkMarker { get; }
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<string> Strings { get; }

    public CardData(OCG_CardData data, string name, string description, List<string> strings)
    {
        Code = data.code;
        Alias = data.alias;
        Type = data.type;
        Level = data.level;
        Attribute = data.attribute;
        Race = data.race;
        Attack = data.attack;
        Defense = data.defense;
        LeftScale = data.lscale;
        RightScale = data.rscale;
        LinkMarker = data.link_marker;
        Name = name;
        Description = description;
        Strings = strings;
    }
}

/*
 *
 *public uint code;
    public uint alias;
    public IntPtr setcode;
    public uint type;
    public uint level;    // O Level vem depois
    public uint attribute;
    public ulong race;
    private uint _padding;     // Padding implícito do C++
    public int attack;    // O Ataque vem aqui
    public int defense;   // A Defesa vem aqui
    public uint lscale;
    public uint rscale;
    public uint link_marker;
 *
 */