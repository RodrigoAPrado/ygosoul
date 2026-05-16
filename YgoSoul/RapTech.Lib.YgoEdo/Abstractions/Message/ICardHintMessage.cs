using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;

public interface ICardHintMessage : IDuelMessage
{
    public IFullLocationReference LocationReference { get; }
    public DuelCardHint CardHint { get; }
    public string Description { get; }
}