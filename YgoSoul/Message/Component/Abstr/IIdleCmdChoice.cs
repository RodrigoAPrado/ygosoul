namespace YgoSoul.Message.Component.Abstr;

public interface IIdleCmdChoice
{
    PlayerIdleAction Action { get; }
    byte Player { get; }
    uint Index { get; }
}