using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class HintOpSelectedMessage : BaseHintMessage
{
    public byte Player { get; }
    public ulong Description { get; }

    public HintOpSelectedMessage(byte player, ulong description) : base(
        $"$Player {player}, choose {DescriptionHandler.GetDescription(description)}")
    {
        Player = player;
        Description = description;
    }
}