using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class HintOpSelectedMessage : BaseHintMessage, IHintOpSelectedMessage
{
    public byte Player { get; }
    public string Description => DescriptionHandler.GetDescription(_description);
    private readonly ulong _description;
    
    public HintOpSelectedMessage(byte player, ulong description) : base(
        $"$Player {player}, choose {DescriptionHandler.GetDescription(description)}")
    {
        Player = player;
        _description = description;
    }
}