using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

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