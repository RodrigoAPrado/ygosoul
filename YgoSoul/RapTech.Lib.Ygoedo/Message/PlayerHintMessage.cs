using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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