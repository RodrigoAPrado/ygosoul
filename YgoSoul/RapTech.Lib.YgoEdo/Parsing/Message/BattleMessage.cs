using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class BattleMessage : BaseMessage, IBattleMessage
{
    public IBattleReference Attacker => _attacker;
    public IBattleReference Defender => _defender;
    private readonly BattleReference _attacker;
    private readonly BattleReference _defender;

    public BattleMessage(
        BattleReference attacker,
        BattleReference defender
        )
    {
        _attacker = attacker;
        _defender = defender;
    }

    public override string ToString()
    {
        return $"[Attacker={_attacker}, Defender={_defender}]";
    }
}