using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class HintEventMessage : BaseHintMessage
{
    public byte Player { get; }
    public OCG_GameStrings Text { get; }

    public HintEventMessage(byte player, OCG_GameStrings text) : base($"Player {player}, it is {text}.")
    {
        Player = player;
        Text = text;
    }
}