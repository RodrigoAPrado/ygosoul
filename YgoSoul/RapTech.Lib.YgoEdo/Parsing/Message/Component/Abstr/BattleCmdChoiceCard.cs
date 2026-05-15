using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;

public abstract class BattleCmdChoiceCard : BattleCmdChoice
{
    public uint CardCode { get; }
    public byte Controller { get; }
    public OCG_CardLocation Location { get; }
    public uint Sequence { get; }
    
    
    protected BattleCmdChoiceCard(
        PlayerBattleAction action, 
        uint index, 
        uint cardCode, 
        byte controller, 
        OCG_CardLocation location, 
        uint sequence) 
        : base(action, index)
    {
        CardCode = cardCode;
        Controller = controller;
        Location = location;
        Sequence = sequence;
    }
}