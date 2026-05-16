using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface ICardSelectMessage : IDuelMessage
{
    IReadOnlyList<IFullLocationReference> Locations { get; }
}