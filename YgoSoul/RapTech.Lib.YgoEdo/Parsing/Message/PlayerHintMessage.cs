using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class PlayerHintMessage : BaseMessage
{
    public byte Player { get; }
    public OCG_PlayerHint Hint { get; }
    public ulong Description { get; }

    public PlayerHintMessage(byte player, OCG_PlayerHint hint, ulong description)
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