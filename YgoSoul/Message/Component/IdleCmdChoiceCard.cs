using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class IdleCmdChoiceCard : IIdleCmdChoice
{
    public PlayerActions PlayerAction { get; }
    public byte Player { get; }
    public uint ValueIndex { get; }

    private readonly CardLocation _location;
    private readonly uint _sequence;
    private readonly uint _cardCode;

    public IdleCmdChoiceCard(PlayerActions playerAction, byte player, uint valueIndex, CardLocation location, uint sequence, uint cardCode)
    {
        PlayerAction = playerAction;
        Player = player;
        ValueIndex = valueIndex;
        _location = location;
        _sequence = sequence;
        _cardCode = cardCode;
        
    }

    public override string ToString()
    {
        return $"to {PlayerAction.ToString()} {CardLibrary.GetCard(_cardCode).Name}, from {_location.ToString()} at sequence {_sequence}...";
    }
}