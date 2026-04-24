namespace YgoSoul.Flag;

[Flags]
public enum CardPosition : uint
{
    FaceUpAttack = 0x1,
    FaceDownAttack = 0x2,
    FaceUpDefense = 0x4,
    FaceDownDefense = 0x8,
    FaceUp = FaceUpAttack | FaceUpDefense,
    FaceDown = FaceDownAttack | FaceDownDefense,
    Attack = FaceUpAttack | FaceDownAttack,
    Defense = FaceUpDefense | FaceDownDefense
}