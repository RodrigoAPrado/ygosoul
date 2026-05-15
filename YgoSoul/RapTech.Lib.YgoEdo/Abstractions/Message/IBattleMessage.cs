using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface IBattleMessage : IDuelMessage
{
    IBattleReference Attacker { get; }
    IBattleReference Defender { get; }
}