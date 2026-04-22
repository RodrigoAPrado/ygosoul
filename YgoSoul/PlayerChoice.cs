namespace YgoSoul;

public class PlayerChoice
{
    public int PlayerAction { get; }
    public int CardIndex { get; }

    public PlayerChoice(int playerAction, int cardIndex)
    {
        PlayerAction = playerAction;
        CardIndex = cardIndex;
    }
}