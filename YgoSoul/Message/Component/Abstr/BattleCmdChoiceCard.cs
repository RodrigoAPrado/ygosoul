using YgoSoul.Flag;

namespace YgoSoul.Message.Component.Abstr;

public abstract class BattleCmdChoiceCard : BattleCmdChoice
{
    public uint CardCode { get; }
    public byte Controller { get; }
    public CardLocation Location { get; }
    public uint Sequence { get; }
    
    
    protected BattleCmdChoiceCard(
        PlayerBattleAction action, 
        uint index, 
        uint cardCode, 
        byte controller, 
        CardLocation location, 
        uint sequence) 
        : base(action, index)
    {
        CardCode = cardCode;
        Controller = controller;
        Location = location;
        Sequence = sequence;
    }
}