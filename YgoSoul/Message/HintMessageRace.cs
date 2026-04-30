using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class HintMessageRace : BaseMessage
{
    public MonsterRaces Race { get; }
    public HintMessageRace(MonsterRaces race)
    {
        Race = race;
    }

    public override string ToString()
    {
        return $"Hint: Race={Race}";
    }
}