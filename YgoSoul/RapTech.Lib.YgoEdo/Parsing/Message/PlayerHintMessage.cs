using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class PlayerHintMessage : BaseMessage, IPlayerHintMessage
{
    public byte Player { get; }
    public PlayerHint Hint { get; }
    public string Description { get; }
    private readonly OCG_PlayerHint _hint;
    private readonly ulong _description;

    public PlayerHintMessage(byte player, OCG_PlayerHint hint, ulong description)
    {
        Player = player;
        _hint = hint;
        _description = description;
        Hint = hint.ToPlayerHint();
        Description = DescriptionUtil.GetDescription(_description);
    }

    public override string ToString()
    {
        return $"Player={Player}, Hint={_hint}, Description={DescriptionUtil.GetDescription(_description)}";
    }
}