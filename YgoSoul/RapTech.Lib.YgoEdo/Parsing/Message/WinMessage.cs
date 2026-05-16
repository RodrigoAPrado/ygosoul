using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class WinMessage : IOcgMessage
{
    public InputType Input => InputType.Win;
    public int InputCount => 0;
    public byte Player { get; }
    public byte Reason { get; }

    public WinMessage(byte player, byte reason)
    {
        Player = player;
        Reason = reason;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        return [];
    }

    public override string ToString()
    {
        return $"Player {Player} won the duel! Reason: {(OCG_VictoryReason)Reason}";
    }
}