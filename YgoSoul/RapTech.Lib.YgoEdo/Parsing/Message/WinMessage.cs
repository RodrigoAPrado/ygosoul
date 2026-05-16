using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class WinMessage : IOcgMessage, IWinMessage
{
    public InputType Input => InputType.Win;
    public int InputCount => 0;
    public byte Player { get; }
    public SystemVictoryReason Reason { get; }
    private OCG_VictoryReason _reason;

    public WinMessage(byte player, OCG_VictoryReason reason)
    {
        Player = player;
        _reason = reason;
        Reason = _reason.ToSystemVictoryReason();
    }
    
    public byte[] GetResponse(List<int> input)
    {
        return [];
    }

    public override string ToString()
    {
        return $"Player {Player} won the duel! Reason: {_reason}";
    }
}