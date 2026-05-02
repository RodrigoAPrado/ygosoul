using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class HintMessageRace : BaseMessage
{
    public byte Player { get; }
    public MonsterRaces Race { get; }
    public HintMessageRace(byte player, MonsterRaces race)
    {
        Player = player;
        Race = race;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player}, Race={Race}";
    }
}