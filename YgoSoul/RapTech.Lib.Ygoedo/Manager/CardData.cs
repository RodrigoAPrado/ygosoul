using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;
using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface.Enum;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;

public class CardData : ICardData
{
    public OCG_CardData Data { get; }
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<string> Strings { get; }
    public uint Code => Data.code;
    public uint Alias => Data.alias;
    public uint Level => Data.level;
    public MonsterType Type { get; }
    public CardFrame Frame { get; }
    public CardIcon Icon { get; }
    public int OriginalAttack => Data.attack;
    public int OriginalDefense => Data.defense;
    public uint LeftScale => Data.lscale;
    public uint RightScale => Data.rscale;
    public IReadOnlyList<LinkArrow> LinkArrows { get; }
    public IReadOnlyList<CardDataType> Types { get; }
    public IReadOnlyList<CardSearchCategory> Categories { get; }
    public ulong Category { get; }
    private static readonly CardData EmptyData 
        = new CardData(new OCG_CardData(), "Monster", "", [], 0);

    public CardData(OCG_CardData data, string name, string description, List<string> strings, ulong category)
    {
        Data = data;
        Name = name;
        Description = description;
        Strings = strings;
        Category = category;
        Type = ((MonsterRaces)data.race).ToMonsterType();
        LinkArrows = SetupLinkArrows();
        Types = SetupTypes();
        Categories = SetupCategories();
        Frame = SetupCardFrame();
        Icon = SetupCardIcon();
    }

    private CardIcon SetupCardIcon()
    {
        if (Data.attribute != 0)
            return ((MonsterAttributes)Data.attribute).ToCardIcon();
        return Frame == CardFrame.Spell ? CardIcon.Spell : CardIcon.Trap;
    }

    private CardFrame SetupCardFrame()
    {
        if (Types.Contains(CardDataType.Spell))
            return CardFrame.Spell;
        if (Types.Contains(CardDataType.Trap))
            return CardFrame.Trap;
        if (Types.Contains(CardDataType.Link))
            return CardFrame.Link;
        if (Types.Contains(CardDataType.Token))
            return CardFrame.Token;
        return GetMonsterFrame(Types.Contains(CardDataType.Pendulum));
    }

    private CardFrame GetMonsterFrame(bool isPendulum)
    {
        if (Types.Contains(CardDataType.Fusion))
            return isPendulum ? CardFrame.FusionPendulum : CardFrame.Fusion;
        if(Types.Contains(CardDataType.Synchro))
            return isPendulum ? CardFrame.SynchroPendulum : CardFrame.Synchro;
        if(Types.Contains(CardDataType.Xyz))
            return isPendulum ? CardFrame.XyzPendulum : CardFrame.Xyz;
        if(Types.Contains(CardDataType.Ritual))
            return isPendulum ? CardFrame.RitualPendulum : CardFrame.Ritual;
        if(Types.Contains(CardDataType.Effect))
            return isPendulum ? CardFrame.EffectPendulum : CardFrame.Effect;
        return isPendulum ? CardFrame.NormalPendulum : CardFrame.Normal;
    }

    private List<LinkArrow> SetupLinkArrows()
    {
        var links = new List<LinkArrow>();

        foreach (LinkMarker l in Enum.GetValues(typeof(LinkMarker)))
        {
            if (l == LinkMarker.None)
                continue;
            if(((uint) l & Data.link_marker) == 1)
                links.Add(l.ToLinkArrow());
        }
        
        return links;
    }

    private List<CardDataType> SetupTypes()
    {
        var types = new List<CardDataType>();

        foreach (CardType t in Enum.GetValues(typeof(CardType)))
        {
            if(((uint) t & Data.type) == 1)
                types.Add(t.ToCardDataType());
        }

        return types;
    }

    private List<CardSearchCategory> SetupCategories()
    {
        var categories = new List<CardSearchCategory>();
        
        foreach (CardCategory c in Enum.GetValues(typeof(CardCategory)))
        {
            if(((ulong) c & Category) == 1)
                categories.Add(c.ToCardSearchCategory());
        }
        
        if(categories.Count == 0)
            categories.Add(CardSearchCategory.None);

        return categories;
    }

    public static CardData GetEmpty()
    {
        return EmptyData;
    }
}