using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

public interface IDuelMessage
{
    int InputCount { get; }
    InputType Input { get; }
}