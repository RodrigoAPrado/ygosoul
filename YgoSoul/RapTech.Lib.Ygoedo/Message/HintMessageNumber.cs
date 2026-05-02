using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class HintMessageNumber : BaseMessage
{
    public byte Player { get; }
    public ulong Number { get; }
    public HintMessageNumber(byte player, ulong number)
    {
        Player = player;
        Number = number;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player}, Number={Number}";
    }
}