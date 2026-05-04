using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;

public interface ICardData
{
    string Name { get; }
    string Description { get; }
    IReadOnlyList<string> Strings { get; }
    uint Code { get; }
    uint Alias { get; }
    uint Level { get; }
    MonsterType Type { get; }
    CardFrame Frame { get; }
    CardIcon Icon { get; }
    int OriginalAttack { get; }
    int OriginalDefense { get; }
    uint LeftScale { get; }
    uint RightScale { get; }
    IReadOnlyList<LinkArrow> LinkArrows{ get; }
    IReadOnlyList<CardDataType> Types { get; }
    IReadOnlyList<CardSearchCategory> Categories { get; }
}