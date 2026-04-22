namespace YgoSoul.Message.Component.Abstr;

public interface IIdleCmdChoice
{
    PlayerActions PlayerAction { get; }
    int ValueIndex { get; }
}