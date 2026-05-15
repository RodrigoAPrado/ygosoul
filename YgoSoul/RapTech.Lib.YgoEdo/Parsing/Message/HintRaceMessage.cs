using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class HintRaceMessage : BaseMessage
{
    public byte Player { get; }
    public OCG_MonsterRaces Race { get; }
    public HintRaceMessage(byte player, OCG_MonsterRaces race)
    {
        Player = player;
        Race = race;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player}, Race={Race}";
    }
}