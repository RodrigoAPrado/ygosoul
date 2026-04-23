using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class IdleCmdChoiceCard : IIdleCmdChoice
{
    public PlayerActions PlayerAction { get; }
    public int ValueIndex { get; }

    private readonly CardLocation _location;
    private readonly uint _positionIndex;
    private readonly uint _cardCode;

    public IdleCmdChoiceCard(PlayerActions playerAction, int valueIndex, CardLocation location, uint positionIndex, uint cardCode)
    {
        PlayerAction = playerAction;
        ValueIndex = valueIndex;
        _location = location;
        _positionIndex = positionIndex;
        _cardCode = cardCode;
    }

    public override string ToString()
    {
        return $"to {PlayerAction.ToString()} {CardLibrary.GetCard(_cardCode).Name}, from {_location.ToString()} at position {_positionIndex+1}...";
    }
}