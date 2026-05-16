using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Base;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface ISelectBattleCommandMessage : IDuelMessage
{
    byte Player { get; }
    public IReadOnlyList<IBattleCommand> Choices { get; }
}