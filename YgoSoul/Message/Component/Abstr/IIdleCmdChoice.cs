namespace YgoSoul.Message.Component.Abstr;

public interface IIdleCmdChoice
{
    PlayerActions PlayerAction { get; }
    byte Player { get; }
    uint ValueIndex { get; }
}