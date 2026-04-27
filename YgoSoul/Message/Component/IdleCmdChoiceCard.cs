using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Handler;
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
    public ulong Description { get; }

    public IdleCmdChoiceCard(PlayerIdleAction playerIdleAction, uint cardCode, byte player, CardLocation location, uint sequence, uint index, ulong description)
    {
        Action = playerIdleAction;
        Player = player;
        Sequence = sequence;
        Location = location;
        CardCode = cardCode;
        Index = index;
        Description = description;
    }

    public override string ToString()
    {
        var description = "";
        if (Action == PlayerIdleAction.EffectActivation)
        {
            description = $", Description={DescriptionHandler.GetDescription(Description)}";
        }
            
        return $"to {Action.ToString()} {CardLibrary.GetCard(CardCode).Name}, Location={Location.ToString()}, Sequence={Sequence}, Index={Index}{description}...";
    }
}