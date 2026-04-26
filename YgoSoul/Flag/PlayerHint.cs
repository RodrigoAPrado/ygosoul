namespace YgoSoul.Flag;

[Flags]
public enum PlayerHint : byte
{
    PlayerAdd = 0x6,
    PlayerRemove = 0x7
}