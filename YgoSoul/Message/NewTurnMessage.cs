using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class NewTurnMessage : HintMessage
{
    public byte Player { get; }
    public NewTurnMessage(byte player) : base($"Your turn, {player}")
    {
        Player = player;
    }
}