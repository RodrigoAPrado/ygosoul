namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

public interface ISelectionsMessage : IOcgMessage
{
    bool CanCancel { get; }
    byte[] Cancel();
}