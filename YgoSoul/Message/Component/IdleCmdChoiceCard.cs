using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class IdleCmdChoiceCard : IIdleCmdChoice
{
    public PlayerIdleAction Action { get; }
    public byte Player { get; }
    public uint Index { get; }
    public uint Sequence { get; }
    public CardLocation Location { get; }
    public uint CardCode { get; }

    public IdleCmdChoiceCard(PlayerIdleAction playerIdleAction, uint cardCode, byte player, CardLocation location, uint sequence, uint index)
    {
        Action = playerIdleAction;
        Player = player;
        Sequence = sequence;
        Location = location;
        CardCode = cardCode;
        Index = index;
    }

    public override string ToString()
    {
        return $"to {Action.ToString()} {CardLibrary.GetCard(CardCode).Name}, from {Location.ToString()} at sequence {Sequence}, Index {Index}...";
    }
}