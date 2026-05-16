using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class HintOpSelectedMessage : BaseHintMessage, IHintOpSelectedMessage
{
    public byte Player { get; }
    public string Description { get; }
    private readonly ulong _description;
    
    public HintOpSelectedMessage(byte player, ulong description) : base(
        $"$Player {player}, choose {DescriptionUtil.GetDescription(description)}")
    {
        Player = player;
        _description = description;
        Description = DescriptionUtil.GetDescription(_description);
    }
}