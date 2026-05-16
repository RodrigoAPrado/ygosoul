using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Base;

public interface IDuelMessage
{
    int InputCount { get; }
    InputType Input { get; }
}