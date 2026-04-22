using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class IdleCmdChoiceCard : IIdleCmdChoice
{
    public PlayerActions PlayerAction { get; }
    public int ValueIndex { get; }

    private readonly CardLocation _location;
    private readonly int _positionIndex;
    private readonly string _cardName;

    public IdleCmdChoiceCard(PlayerActions playerAction, int valueIndex, CardLocation location, int positionIndex, string cardName)
    {
        PlayerAction = playerAction;
        ValueIndex = valueIndex;
        _location = location;
        _positionIndex = positionIndex;
        _cardName = cardName;
    }

    public override string ToString()
    {
        return $"to {PlayerAction.ToString()} {_cardName}, from {_location.ToString()} at position {_positionIndex+1}...";
    }
}