using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class IdleCmdChoiceCard : IIdleCmdChoice
{
    public PlayerIdleAction Action { get; }
    public byte Player { get; }
    public uint Index { get; }
    public uint Sequence { get; }
    public OCG_CardLocation Location { get; }
    public uint CardCode { get; }
    public ulong Description { get; }

    public IdleCmdChoiceCard(PlayerIdleAction playerIdleAction, uint cardCode, byte player, OCG_CardLocation location, uint sequence, uint index, ulong description)
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
            
        return $"to {Action.ToString()} {CardLibrary.InternalGetCard(CardCode).Name}, Location={Location.ToString()}, Sequence={Sequence}, Index={Index}{description}...";
    }
}