using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

public interface ISelectionOcgMessage : IOcgMessage, ISelectionDuelMessage
{
    byte[] Cancel();
}