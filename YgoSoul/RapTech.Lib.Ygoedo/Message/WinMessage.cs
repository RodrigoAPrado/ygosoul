using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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
        return $"Player {Player} won the duel! Reason: {(VictoryReason)Reason}";
    }
}