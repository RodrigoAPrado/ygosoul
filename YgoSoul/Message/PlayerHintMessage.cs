using YgoSoul.Flag;
using YgoSoul.Handler;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class PlayerHintMessage : BaseMessage
{
    public byte Player { get; }
    public PlayerHint Hint { get; }
    public ulong Description { get; }

    public PlayerHintMessage(byte player, PlayerHint hint, ulong description)
    {
        Player = player;
        Hint = hint;
        Description = description;
    }

    public override string ToString()
    {
        return $"Player={Player}, Hint={Hint}, Description={DescriptionHandler.GetDescription(Description)}";
    }
}