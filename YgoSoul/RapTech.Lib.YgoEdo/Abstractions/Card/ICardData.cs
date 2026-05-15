using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;

namespace YgoSoul.RapTech.Lib.YgoEdo.Manager.Interface;

public interface ICardData
{
    string Name { get; }
    string Description { get; }
    IReadOnlyList<string> Strings { get; }
    uint Code { get; }
    uint Alias { get; }
    uint Level { get; }
    MonsterType Type { get; }
    Frame Frame { get; }
    CardAttribute CardAttribute { get; }
    int OriginalAttack { get; }
    int OriginalDefense { get; }
    uint LeftScale { get; }
    uint RightScale { get; }
    IReadOnlyList<LinkArrow> LinkArrows{ get; }
    IReadOnlyList<CardType> Types { get; }
    IReadOnlyList<SearchCategory> Categories { get; }
}